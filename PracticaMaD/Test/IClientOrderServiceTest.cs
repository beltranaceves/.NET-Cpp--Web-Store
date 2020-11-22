using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Service.ClientOrderService;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderLineService;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    [TestClass]
    public class IClientOrderServiceTest
    {
        private static IKernel kernel;

        private static IClientService clientService;
        private static ICreditCardService creditCardService;
        private static IProductService productService;
        private static IClientOrderService clientOrderService;
        private static ICategoryDao categoryDao;

        private static IClientDao clientDao;

        private static IProductDao productDao;
        private static ICreditCardDao creditCardDao;
        private static IClientOrderDao clientOrderDao;
        private static IClientOrderLineDao clientOrderLineDao;

        public TestContext TestContext { get; set; }

        #region Additional test attributes

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            categoryDao = kernel.Get<ICategoryDao>();
            creditCardDao = kernel.Get<ICreditCardDao>();
            clientDao = kernel.Get<IClientDao>();
            productDao = kernel.Get<IProductDao>();
            clientOrderDao = kernel.Get<IClientOrderDao>();
            clientOrderLineDao = kernel.Get<IClientOrderLineDao>();
            clientOrderService = kernel.Get<IClientOrderService>();
            clientService = kernel.Get<IClientService>();
            creditCardService = kernel.Get<ICreditCardService>();
            productService = kernel.Get<IProductService>();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
        }

        #endregion Additional test attributes

        private static long CreateProduct(long categoryId, string productName, int stock, float price)
        {
            Product p = new Product();
            p.categoryId = categoryId;
            p.productName = productName;
            p.stock = stock;
            p.price = price;
            p.registerDate = DateTime.Now;

            productDao.Create(p);

            return p.productId;
        }

        private static long CreateCategory(string categoryName)
        {
            Category category = new Category();

            category.categoryName = categoryName;

            categoryDao.Create(category);

            return category.categoryId;
        }

        private static long RegisterClient(string clientLogin, string clientPassword)
        {
            ClientDetails client = new ClientDetails("firstaname", "firstSurname", "lastSurname",
            "email@udc.es", "spanish", "home", "user");
            return clientService.RegisterClient(clientLogin, clientPassword, client);
        }

        private static void AddCard(long clientId)
        {
            CreditCardDetails creditCard = new CreditCardDetails("1234567890123456", 000, "02/21", "Visa");
            creditCardService.AddCard(clientId, creditCard);
        }

        [TestMethod()]
        public void GenerateOrderTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, 10);
                int quantity = 2;
                long productId2 = CreateProduct(categoryId, "La leyenda de Korra", 20, 20);
                int quantity2 = 3;

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname", "secondONe",
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client222", "password", client);

                // Create the cart

                List<ClientOrderLineDetails> cart = new List<ClientOrderLineDetails>();

                ClientOrderLineDetails orderLine1 = new ClientOrderLineDetails(productId, quantity, 10);
                cart.Add(orderLine1);

                ClientOrderLineDetails orderLine2 = new ClientOrderLineDetails(productId2, quantity2, 20);
                cart.Add(orderLine2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("098765432109876", 000, "02/21", "Visa");
                creditCardService.AddCard(clientId, card);

                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "PedidoEjemplo", "toHome", cart);

                ClientOrder clientOrder = clientOrderDao.Find(clientOrderId);

                Assert.AreEqual(clientOrderId, clientOrder.orderId);
                Assert.AreEqual(clientId, clientOrder.clientId);
                Assert.AreEqual(cardId, clientOrder.creditCardId);
                Assert.AreEqual("toHome", clientOrder.clientOrderAddress);
                Assert.AreEqual("PedidoEjemplo", clientOrder.orderName);
                Assert.AreEqual(8, clientOrder.ClientOrderLine.ElementAt(0).Product.stock);
                Assert.AreEqual(cart[0].ProductId, clientOrder.ClientOrderLine.ElementAt(0).Product.productId);
                Assert.AreEqual(cart[0].Quantity, clientOrder.ClientOrderLine.ElementAt(0).quantity);
                Assert.AreEqual(cart[0].Price, clientOrder.ClientOrderLine.ElementAt(0).Product.price);
                Assert.AreEqual(17, clientOrder.ClientOrderLine.ElementAt(1).Product.stock);
                Assert.AreEqual(cart[1].ProductId, clientOrder.ClientOrderLine.ElementAt(1).Product.productId);
                Assert.AreEqual(cart[1].Quantity, clientOrder.ClientOrderLine.ElementAt(1).quantity);
                Assert.AreEqual(cart[1].Price, clientOrder.ClientOrderLine.ElementAt(1).Product.price);
            }
        }

        [TestMethod()]
        public void FindOrderTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, 10);
                int quantity = 2;
                long productId2 = CreateProduct(categoryId, "La leyenda de Korra", 10, 20);
                int quantity2 = 3;

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname", "secondONe",
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client333", "password", client);

                // Create the cart

                List<ClientOrderLineDetails> cart = new List<ClientOrderLineDetails>();

                ClientOrderLineDetails orderLine1 = new ClientOrderLineDetails(productId, quantity, 10);
                cart.Add(orderLine1);

                ClientOrderLineDetails orderLine2 = new ClientOrderLineDetails(productId2, quantity2, 20);
                cart.Add(orderLine2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("1234567890123456", 000, "02/21", "Visa");
                creditCardService.AddCard(clientId, card);

                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "PedidoEjemplo", "toHome", cart);

                // FinOrder
                ClientOrderDetails clientOrder = clientOrderService.FindOrder(clientOrderId);

                ClientOrder order = clientOrderDao.Find(clientOrderId);

                Assert.AreEqual(clientOrder.OrderName, order.orderName);
                Assert.AreEqual(clientOrder.ClientId, order.clientId);
                Assert.AreEqual(clientOrder.CreditCardId, cardId);
                Assert.AreEqual(clientOrder.ClientOrderAddress, "toHome");
            }
        }

        [TestMethod()]
        public void GetClientOrdersTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, 10);
                int quantity = 2;
                long productId2 = CreateProduct(categoryId, "La leyenda de Korra", 20, 20);
                int quantity2 = 3;

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname", "secondONe",
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client333", "password", client);

                // Create the cart

                List<ClientOrderLineDetails> cart = new List<ClientOrderLineDetails>();

                ClientOrderLineDetails orderLine1 = new ClientOrderLineDetails(productId, quantity, 10);
                cart.Add(orderLine1);

                ClientOrderLineDetails orderLine2 = new ClientOrderLineDetails(productId2, quantity2, 20);
                cart.Add(orderLine2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("1234567890123456", 000, "02/21", "Visa");
                creditCardService.AddCard(clientId, card);

                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "NombrePedido", "toHome", cart);

                // FinOrder
                List<ClientOrderDetails> clientOrders = clientOrderService.getClientOrders(clientId);

                ClientOrder clientOrder = clientOrderDao.Find(clientOrderId);

                Assert.AreEqual(clientOrders.ElementAt(0).OrderName, clientOrder.orderName);
                Assert.AreEqual(clientOrders.ElementAt(0).ClientId, clientOrder.clientId);
                Assert.AreEqual(clientOrders.ElementAt(0).CreditCardId, clientOrder.creditCardId);
                Assert.AreEqual(clientOrders.ElementAt(0).ClientOrderAddress, "toHome");
            }
        }

        // <summary>
        ///A test for GetOrdersByUser
        ///</summary>
        [TestMethod()]
        public void GetNumberOfOrdersByClientTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, 10);
                int quantity = 2;
                long productId2 = CreateProduct(categoryId, "La leyenda de Korra", 20, 20);
                int quantity2 = 3;
                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname", "secondONe",
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client333", "password", client);

                // Create the cart

                List<ClientOrderLineDetails> cart = new List<ClientOrderLineDetails>();

                ClientOrderLineDetails orderLine1 = new ClientOrderLineDetails(productId, quantity, 10);
                cart.Add(orderLine1);

                ClientOrderLineDetails orderLine2 = new ClientOrderLineDetails(productId2, quantity2, 20);
                cart.Add(orderLine2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("1234567890123456", 000, "02/21", "Visa");
                creditCardService.AddCard(clientId, card);

                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "Pedido", "toHome", cart);

                int clientOrdersByClient = clientOrderService.GetNumberOfOrdersByClient(clientId);

                // Check the data
                Assert.AreEqual(1, clientOrdersByClient);
            }
        }
    }
}