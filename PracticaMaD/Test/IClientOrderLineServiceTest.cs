﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService;
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
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService;
using Es.Udc.DotNet.PracticaMad.Model.Service.ClientOrderLineService;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    [TestClass]
    public class IClientOrderLineServiceTest
    {
        private static IKernel kernel;

        private static IClientService clientService;
        private static ICreditCardService creditCardService;
        private static IProductService productService;
        private static IShoppingCartService shoppingCartService;
        private static IClientOrderService clientOrderService;
        private static IClientOrderLineService clientOrderLineService;
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
            clientOrderLineService = kernel.Get<IClientOrderLineService>();
            clientService = kernel.Get<IClientService>();
            creditCardService = kernel.Get<ICreditCardService>();
            productService = kernel.Get<IProductService>();
            shoppingCartService = kernel.Get<IShoppingCartService>();
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
            "email@udc.es", "spanish", "home", "Spain", "user");
            return clientService.RegisterClient(clientLogin, clientPassword, client);
        }

        private static void AddCard(long clientId)
        {
            CreditCardDetails creditCard = new CreditCardDetails("1234567890123456", "Visa", 000, "02/21", false, clientId);
            creditCardService.AddCard(clientId, creditCard);
        }

        [TestMethod()]
        public void GenerateOrderTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");
                float price1 = 10;
                float price2 = 20;
                // Create a product
                long productId = CreateProduct(categoryId, "Avatar la leyenda de Aang", 10, price1);
                int quantity = 2;
                long productId2 = CreateProduct(categoryId, "La leyenda de Korra", 20, price2);
                int quantity2 = 3;

                // Register User
                ClientDetails client = new ClientDetails("client", "firstSurname", "secondONe",
                "client@udc.es", "es", "myhome", "ES", "user");
                long clientId = clientService.RegisterClient("Client222", "password", client);

                // Create the cart

                ShoppingCart shoppingCart = new ShoppingCart();

                //Añadimos las dos lineas al carito
                shoppingCartService.AddToCart(productId, quantity, shoppingCart);
                shoppingCartService.AddToCart(productId2, quantity2, shoppingCart);

                // Add a cards
                string cardNumber = "1234567890123456";
                string cardType = "Visa";
                int verificationCode = 000;
                String expeditionDate = "01/01";

                CreditCardDetails creditCardDetails = new CreditCardDetails(cardNumber, cardType, verificationCode, expeditionDate, true, clientId);

                creditCardService.AddCard(clientId, creditCardDetails);

                long cardId = clientDao.Find(clientId).CreditCard.ElementAt(0).cardId;

                // Generate order
                long clientOrderId = clientOrderService.CreateOrder(clientId, cardId, "PedidoEjemplo", null, shoppingCart);

                ClientOrder clientOrder = clientOrderDao.Find(clientOrderId);


                List<ClientOrderLine> x = clientOrderLineService.GetOrderLines(clientOrder.orderId);


                Assert.AreEqual(productId, x.ElementAt(0).productId);
                Assert.AreEqual(productId2, x.ElementAt(1).productId);

            }
        }

    }
}