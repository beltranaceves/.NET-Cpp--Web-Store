using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.Service.ClientOrderService;
using Es.Udc.DotNet.PracticaMaD.Model.ProductDao;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderService;

namespace Es.Udc.DotNet.PracticaMad.Test
{

    [TestClass]
    public class IOrderServiceTest
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

        TransactionScope transaction;
        private TestContext testContextInstance;

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

        #endregion

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

        private static long RegisterClient(string clientLogin,string clientPassword)
        {
            ClientDetails client = new ClientDetails("firstaname", "firstSurname","lastSurname", 
            "email@udc.es", "spanish", "home", "user");
            return clientService.RegisterClient(clientLogin, clientPassword, client);
        }

        private static void AddCard(long clientId)
        {
            CreditCardDetails creditCard = new CreditCardDetails("1234567890123456","Visa",000,DateTime.Now);
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
                long product2Id = CreateProduct(categoryId, "La leyenda de Korra", 10, 20);

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname","secondONe", 
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client222", "password", client);

                // Get Products
                
                List<ProductDetails> cart = new List<ProductDetails>();

                ProductDetails product = productService.FindProduct(productId);
                product.numberOfUnits = 1;
                
                ProductDetails product2 = productService.FindProduct(product2Id);
                
                cart.Add(product);
                cart.Add(product2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("0987654321098765","MasterCard",111,DateTime.Now);
                creditCardService.AddCard(clientId, card);
                
                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "toHome", cart);

                ClientOrder clientOrder = clientOrderDao.Find(clientOrderId);

                Assert.AreEqual(clientOrderId, clientOrder.orderId);
                Assert.AreEqual(clientOrder.clientId, clientId);
                Assert.AreEqual(cardId, clientOrder.creditCardId);
                Assert.AreEqual("toHome", clientOrder.clientOrderAddress);
                //Assert.AreEqual(cart.Count, order.OrderLines.Count);
                Assert.AreEqual(cart[0].productId, clientOrder.ClientOrderLine.ElementAt(0).productId);
                Assert.AreEqual(cart[1].productId, clientOrder.ClientOrderLine.ElementAt(1).productId);
            }
        }

        [TestMethod()]
        public void getClientOrderTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                   // Create a category
                long categoryId = CreateCategory("Books");

                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, 10);
                long product2Id = CreateProduct(categoryId, "La leyenda de Korra", 10, 20);

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname","secondONe", 
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client333", "password", client);

                // Get Products
                
                List<ProductDetails> cart = new List<ProductDetails>();

                ProductDetails product = productService.FindProduct(productId);
                product.numberOfUnits = 1;
                
                ProductDetails product2 = productService.FindProduct(product2Id);
                
                cart.Add(product);
                cart.Add(product2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("1526237162782716","Visa",123,DateTime.Now);
                creditCardService.AddCard(clientId, card);
                
                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "toHome", cart);

                // FinOrder
                ClientOrderDetails clientOrder = clientOrderService.FindOrder(clientOrderId);

                ClientOrder order = clientOrderDao.Find(clientOrderId);

                Assert.AreEqual(clientOrder.OrderId, order.orderId);
                Assert.AreEqual(clientOrder.ClientId, order.clientId);
                Assert.AreEqual(clientOrder.creditCardId, cardId);
                Assert.AreEqual(clientOrder.PostalAddress, "toHome");
            }
        }

     
        [TestMethod()]
        public void getClientOrders()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, 10);
                long product2Id = CreateProduct(categoryId, "La leyenda de Korra", 10, 20);

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname","secondONe", 
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client333", "password", client);

                // Get Products
                
                List<ProductDetails> cart = new List<ProductDetails>();

                ProductDetails product = productService.FindProduct(productId);
                product.numberOfUnits = 1;
                
                ProductDetails product2 = productService.FindProduct(product2Id);
                
                cart.Add(product);
                cart.Add(product2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("1526237162782716","Visa",123,DateTime.Now);
                creditCardService.AddCard(clientId, card);
                
                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "toHome", cart);

           
                // FinOrder
                List<ClientOrderDetails> clientOrders = clientOrderService.getClientOrders(clientId,0,2);

                ClientOrder clientOrder = clientOrderDao.Find(orderId);

                Assert.AreEqual(clientOrders.ElementAt(0).OrderId, clientOrder.orderId);
                Assert.AreEqual(clientOrders.ElementAt(0).ClientId,clientOrder.clientId);
                Assert.AreEqual(clientOrders.ElementAt(0).creditCardId, clientOrder.cardId);
                Assert.AreEqual(clientOrders.ElementAt(0).clientOrderAddress, "toHome");
            }
        }

        // <summary>
        ///A test for GetOrdersByUser
        ///</summary>
        [TestMethod()]
        public void GetOrdersByClientTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                 // Create a category
                long categoryId = CreateCategory("Books");

                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, 10);
                long product2Id = CreateProduct(categoryId, "La leyenda de Korra", 10, 20);

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname","secondONe", 
                "client@udc.es", "spanish", "myhome", "user");
                long clientId = clientService.RegisterClient("Client333", "password", client);

                // Get Products
                
                List<ProductDetails> cart = new List<ProductDetails>();

                ProductDetails product = productService.FindProduct(productId);
                product.numberOfUnits = 1;
                
                ProductDetails product2 = productService.FindProduct(product2Id);
                
                cart.Add(product);
                cart.Add(product2);

                // Add card
                CreditCardDetails card = new CreditCardDetails("1526237162782716","Visa",123,DateTime.Now);
                creditCardService.AddCard(clientId, card);
                
                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "toHome", cart);
 
                int clientOrdersByClient = clientOrderService.GetOrdersByClient(clientId);

                // Check the data
                Assert.AreEqual(1, clientOrdersByClient);
            }
        }
    }
}
