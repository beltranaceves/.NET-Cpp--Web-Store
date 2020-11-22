using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
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
        public long CreateOrder(long clientId, long cardId, string clientOrderAddress, List<ProductDetails> productList)
        {
            ClientOrder order = new ClientOrder();
            order.clientId = clientId;
            order.creditCardId = cardId;
            order.orderDate = DateTime.Now;
            order.clientOrderAddress = clientOrderAddress;
            order.orderName = "Order";

            ClientOrderDao.Create(order);

            long orderId = order.orderId;
            
            for (int i = 0; i < productList.Count; i++)
            {
                String productName = productList.ElementAt(i).ProductName;

                Product product = ProductDao.FindByProductName(productName);

                long productId = product.productId;

                int stock = productList.ElementAt(i).Stock;
                
                int newStock = product.stock - productList.ElementAt(i).Stock;
                
                if (newStock < 0)
                    throw new NotEnoughStockException(product.productName, newStock);
                
                product.stock = newStock;
                
                ProductDao.Update(product);
                
                ClientOrderLine clientOrderLine = new ClientOrderLine();
                
                clientOrderLine.orderId = orderId;
                clientOrderLine.productId = productId;
                clientOrderLine.quantity = stock;
                clientOrderLine.price = product.price;
                ClientOrderLineDao.Create(clientOrderLine);
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
                
                List<ClientOrderLine> clientOrderLines = clientOrders.ElementAt(i).ClientOrderLine.ToList();

                
                List<ClientOrderLineDetails> clientOrderLinesDetails = new List<ClientOrderLineDetails>();
                
                for (int j = 0; j < clientOrderLines.Count; j++)
                {
                    long productId = clientOrderLines.ElementAt(j).Product.productId;
                    int quantity = clientOrderLines.ElementAt(j).quantity;
                    double price = (double)clientOrderLines.ElementAt(j).price;
                    
                    ClientOrderLineDetails clientOrderLine = new ClientOrderLineDetails(clientOrders.ElementAt(i).orderId, productId, quantity, price);
                    
                    clientOrderLinesDetails.Add(clientOrderLine);
                }
                
                long cardId =clientOrders.ElementAt(i).CreditCard.cardId;
                long orderId = clientOrders.ElementAt(i).orderId;
                //string cardNumber = CreditCardDao.Find(clientOrders.ElementAt(i).creditCardId).cardNumber;
                String postalAddress = clientOrders.ElementAt(i).clientOrderAddress;
                DateTime orderDate = clientOrders.ElementAt(i).orderDate;
                var orderName = "Order";
                clientOrdersDetails.Add(new ClientOrderDetails(orderDate, orderName, cardId,postalAddress,clientId));
                
                k++;
            }
            return clientOrdersDetails;
        }

        //Returns the order given its id

        public ClientOrderDetails FindOrder(long orderId)
        {
            ClientOrder order = ClientOrderDao.Find(orderId);
            
            ClientOrderDetails orderDetails = new ClientOrderDetails(order.orderDate,order.orderName,order.CreditCard.cardId,
                order.clientOrderAddress,order.Client.clientId);
            
            return orderDetails;
        }


        //Counts how many orders a client has 

        public int GetNumberOfOrdersByClient(long usrId)
        {
            int number = 0;
            try
            {
                number = ClientDao.Find(usrId).ClientOrder.Count;
            } catch (InstanceNotFoundException e)
            {
                throw new InstanceNotFoundException(usrId, "Client not found");
            }
            return number;
        }
    }
}
