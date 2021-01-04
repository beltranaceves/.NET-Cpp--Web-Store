using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderLineService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService
{
    public class ClientOrderService : IClientOrderService
    {
        [Inject]
        public ICreditCardDao CreditCardDao { private get; set; }

        [Inject]
        public IClientDao ClientDao { private get; set; }

        [Inject]
        public IProductDao ProductDao { private get; set; }

        [Inject]
        public IClientOrderLineDao ClientOrderLineDao { private get; set; }

        [Inject]
        public IClientOrderDao ClientOrderDao { private get; set; }

        [Transactional]
        public long CreateOrder(long clientId, long? cardId, string orderName, string clientOrderAddress, ShoppingCart shoppingCart)
        {
            ClientOrder order = new ClientOrder();

            // Pasamos los productos de la cesta a la ClientOrderLine
            foreach (ShoppingCartLine Sline in shoppingCart.shoppingCartLines)
            {
                ClientOrderLine line = new ClientOrderLine();

                Product p = ProductDao.Find(Sline.productId);

                if (p.stock - Sline.quantity < 0)
                    throw new NotEnoughStockException(p.productName, Sline.quantity);

                line.productId = p.productId;
                line.quantity = Sline.quantity;

                order.ClientOrderLine.Add(line);
            }

            //Ahora procedemos a añadir los campos restantes

            Client client = ClientDao.Find(clientId);

            // Si no se nos especifican estos campos, cogemos los de por defecto del usuario

            if (cardId != null)
                order.creditCardId = cardId;
            else
                order.creditCardId = CreditCardDao.GetDefaultCreditCardByClientId(clientId).cardId;

            if (clientOrderAddress != null)
                order.clientOrderAddress = clientOrderAddress;
            else
                order.clientOrderAddress = client.clientAddress;

            order.orderName = orderName;
            long orderId = order.orderId;
            order.orderDate = DateTime.Now;
            order.clientId = clientId;

            double totalPrice = 0;

            //Actualizamos los productos y se va calculando el coste total
            //Comprobando siempre que hay stock suficiente
            foreach (ClientOrderLine ol in order.ClientOrderLine)
            {
                long productId = ol.productId;

                Product product = ProductDao.Find(productId);
                int quantity = ol.quantity;
                int stock = product.stock;

                if (stock < quantity)
                    throw new NotEnoughStockException(product.productName, quantity);

                product.stock = stock - quantity;

                ProductDao.Update(product);

                double price = quantity * product.price;

                ol.price = price;

                totalPrice += price;
            }

            //Establecemos  el coste total de la compra y la generamos
            order.totalPrize = totalPrice;

            ClientOrderDao.Create(order);

            return order.orderId;
        }

        [Transactional]
        public ClientOrderBlock GetClientOrders(long clientId, int startIndex, int count)
        {
            List<ClientOrder> clientOrders = ClientOrderDao.FindByClientId(clientId, startIndex, count + 1);

            bool existMoreOrders = (clientOrders.Count == count + 1);

            if (existMoreOrders)
                clientOrders.RemoveAt(count);
            return new ClientOrderBlock(clientOrders, existMoreOrders);
        }

        //Returns the order given its id
        [Transactional]
        public ClientOrderDetails FindOrder(long orderId)
        {
            ClientOrder order = ClientOrderDao.Find(orderId);

            ClientOrderDetails orderDetails = new ClientOrderDetails(order.orderDate, order.orderName, order.CreditCard.cardId,
                order.clientOrderAddress, order.Client.clientId);

            return orderDetails;
        }
    }
}