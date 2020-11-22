using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderLineService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Service.ClientOrderService
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
        public long CreateOrder(long clientId, long cardId, string orderName, string clientOrderAddress, List<ClientOrderLineDetails> orderLine)
        {
            ClientOrder order = new ClientOrder();
            order.clientId = clientId;
            order.creditCardId = cardId;
            order.orderDate = DateTime.Now;
            order.clientOrderAddress = clientOrderAddress;
            order.orderName = orderName;

            long orderId = order.orderId;

            for (int i = 0; i < orderLine.Count; i++)
            {
                long productId = orderLine.ElementAt(i).ProductId;

                Product product = ProductDao.Find(productId);
                int quantity = orderLine.ElementAt(i).Quantity;
                int stock = product.stock;

                if (stock > quantity)
                    throw new NotEnoughStockException(product.productName, quantity);

                product.stock = stock - quantity;

                ProductDao.Update(product);
            }

            ClientOrderDao.Create(order);
            for (int i = 0; i < orderLine.Count; i++)
            {
                OrderLineDetails orderLineAdd = new OrderLineDetails();
                orderLineAdd.orderId = order.orderId;
                orderLineAdd.quantity = orderLine.ElementAt(i).Quantity;
                orderLineAdd.productId = orderLine.ElementAt(i).ProductId;
                orderLineAdd.price = orderLine.ElementAt(i).Price;

                ClientOrderLineDao.Create(orderLineAdd);
            }

            return orderId;
        }

        [Transactional]
        public List<ClientOrderDetails> getClientOrders(long clientId)
        {
            Client Client = ClientDao.Find(clientId);

            List<ClientOrderDetails> clientOrdersDetails = new List<ClientOrderDetails>();

            List<ClientOrder> clientOrders = Client.ClientOrder.ToList();

            int k = 0;

            for (int i = 0; i < clientOrders.Count; i++)
            {
                if (k == clientOrders.Count)
                    break;

                List<OrderLineDetails> clientOrderLines = clientOrders.ElementAt(i).ClientOrderLine.ToList();

                List<ClientOrderLineDetails> clientOrderLinesDetails = new List<ClientOrderLineDetails>();

                for (int j = 0; j < clientOrderLines.Count; j++)
                {
                    long productId = clientOrderLines.ElementAt(j).Product.productId;
                    int quantity = clientOrderLines.ElementAt(j).quantity;
                    double price = (double)clientOrderLines.ElementAt(j).price;

                    ClientOrderLineDetails clientOrderLine = new ClientOrderLineDetails(productId, quantity, price);

                    clientOrderLinesDetails.Add(clientOrderLine);
                }

                long cardId = clientOrders.ElementAt(i).CreditCard.cardId;

                //string cardNumber = CreditCardDao.Find(clientOrders.ElementAt(i).creditCardId).cardNumber;
                String postalAddress = clientOrders.ElementAt(i).clientOrderAddress;
                DateTime orderDate = clientOrders.ElementAt(i).orderDate;
                var orderName = "Order";
                clientOrdersDetails.Add(new ClientOrderDetails(orderDate, orderName, cardId, postalAddress, clientId));

                k++;
            }
            return clientOrdersDetails;
        }

        //Returns the order given its id

        public ClientOrderDetails FindOrder(long orderId)
        {
            ClientOrder order = ClientOrderDao.Find(orderId);

            ClientOrderDetails orderDetails = new ClientOrderDetails(order.orderDate, order.orderName, order.CreditCard.cardId,
                order.clientOrderAddress, order.Client.clientId);

            return orderDetails;
        }

        //Counts how many orders a client has

        public int GetNumberOfOrdersByClient(long clientId)
        {
            int number = 0;
            try
            {
                number = ClientDao.Find(clientId).ClientOrder.Count;
            }
            catch (InstanceNotFoundException e)
            {
                throw new InstanceNotFoundException(clientId, "Client not found");
            }
            return number;
        }
    }
}