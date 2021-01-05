using System;
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
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using Es.Udc.DotNet.ModelUtil.Exceptions;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    [TestClass]
    public class IShoppingCartTest
    {
        private static IKernel kernel;

        private static IClientService clientService;
        private static IShoppingCartService shoppingCartService;
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

        private static void AddCard(long clientId)
        {
            CreditCardDetails creditCard = new CreditCardDetails("1234567890123456", "Visa", 000, "02/21", false, 1);
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


                ShoppingCart shoppingCartTest = new ShoppingCart();

                //Añadimos las dos lineas al carito
                shoppingCartService.AddToCart(productId, quantity, shoppingCartTest);
                shoppingCartService.AddToCart(productId2, quantity2, shoppingCartTest);
                ShoppingCartLine s1 = shoppingCartTest.shoppingCartLines[0];
                ShoppingCartLine s2 = shoppingCartTest.shoppingCartLines[1];

                //Comprobamos que hay dos lineas en el carrito
                Assert.AreEqual(2, shoppingCartTest.shoppingCartLines.Count);

               //Actualizamos el numero de unidades de la linea 1
                shoppingCartService.UpdateNumberOfUnits(s1, shoppingCartTest, 5);

                Assert.AreEqual(5, shoppingCartTest.shoppingCartLines[0].quantity);

                 //Actualizamos el estado de si es para regalo o no

                shoppingCartService.UpdateForGiftStatus(s1, shoppingCartTest, true);

                Assert.IsTrue(shoppingCartTest.shoppingCartLines[0].forGift);
                
                //Buscamos por una linea en concreto

                Assert.AreEqual(s1, shoppingCartService.GetCartLine(shoppingCartTest.shoppingCartLines[0], shoppingCartTest));

                //Eliminamos ambas lineas de carrito

                shoppingCartService.RemoveFromCart(s1, shoppingCartTest);
                shoppingCartService.RemoveFromCart(s2, shoppingCartTest);

                Assert.AreEqual(0, shoppingCartTest.shoppingCartLines.Count);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void UpdateQuantityLineNotAdded()
        {
            ShoppingCartLine line1 = new ShoppingCartLine();
            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCartService.UpdateNumberOfUnits(line1, shoppingCart, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void UpdateForGifLineNotAdded()
        {
            ShoppingCartLine line1 = new ShoppingCartLine();
            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCartService.UpdateForGiftStatus(line1, shoppingCart, false);
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void GetNonAddedLine()
        {
            ShoppingCartLine line1 = new ShoppingCartLine();
            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCartService.GetCartLine(line1, shoppingCart);
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void RemoveNonExistingLine()
        {
            ShoppingCartLine line1 = new ShoppingCartLine();
            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCartService.RemoveFromCart(line1, shoppingCart);
        }
    }
}