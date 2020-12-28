using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Transactions;
using System;
using Es.Udc.DotNet.ModelUtil.Exceptions;

using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    [TestClass]
    public class IProductCommentServiceTest
    {
        //Variables we're going to use later

        private const String clientLogin = "login1";
        private const String clientPassword = "password";
        private const String firstName = "name";
        private const String firstSurname = "1SurName";
        private const String lastSurname = "2SurName";
        private const String clientAddress = "Calle Test";
        private const String email = "user@udc.es";
        private const String clientLanguage = "es";
        private const String country = "ES";
        private const String rol = "USER";

        private const long NO_CLIENID_FOUND = -1;

        private static IKernel kernel;

        private static IProductDao productDao;
        private static ICategoryDao categoryDao;
        private static IProductCommentDao productCommentDao;
        private static ITagDao tagDao;
        private static IClientDao clientDao;

        private static IProductService productService;
        private static IProductCommentService productCommentService;
        private static IClientService clientService;

        public TestContext TestContext
        { get; set; }

        #region Additional test attributes

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

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            productDao = kernel.Get<IProductDao>();
            categoryDao = kernel.Get<ICategoryDao>();
            productCommentDao = kernel.Get<IProductCommentDao>();
            tagDao = kernel.Get<ITagDao>();
            clientDao = kernel.Get<IClientDao>();
            productCommentService = kernel.Get<IProductCommentService>();
            productService = kernel.Get<IProductService>();
            clientService = kernel.Get<IClientService>();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void AddProductCommentAndFindByProductIdTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;
                // Create a product
                long productId = CreateProduct(categoryId, productName, stock, price);

                String productCommentText = "mi libro favorito";

                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                productCommentService.AddProductComment(productId, productCommentText, clientId);

                List<ProductCommentDetails> productComments = productCommentService.FindByProductId(productId);

                Assert.AreEqual(productComments[0].CommentText, productCommentText);
                Assert.AreEqual(productComments[0].ClientId, clientId);
                Assert.AreEqual(productComments[0].ProductId, productId);

                productCommentDao.Remove(productComments[0].CommentId);
                productDao.Remove(productId);
                clientDao.Remove(clientId);
                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void AddProductCommentInstanceNotFoundExceptionTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a product
                long productId = 2;

                String productCommentText = "mi libro favorito";

                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                productCommentService.AddProductComment(productId, productCommentText, clientId);

                clientDao.Remove(clientId);
                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindByProductIdInstanceNotFoundExceptionTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a product
                long productId = 2;

                String productCommentText = "mi libro favorito";

                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                productCommentService.AddProductComment(productId, productCommentText, clientId);

                List<ProductCommentDetails> productComments = productCommentService.FindByProductId(productId);

                productCommentDao.Remove(productComments[0].CommentId);
                productDao.Remove(productId);
                clientDao.Remove(clientId);
                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        public void TagProductCommentTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Create a category
                long categoryId = CreateCategory("Books");

                String productName = "Avatar la leyenda de Aang";
                int stock = 10;
                float price = 10;

                // Create a product
                long productId = CreateProduct(categoryId, productName, stock, price);

                String productCommentText = "mi libro favorito";

                //Create a client
                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                //Add comment
                productCommentService.AddProductComment(productId, productCommentText, clientId);

                List<ProductCommentDetails> productComments = productCommentService.FindByProductId(productId);

                Tag tag1 = new Tag();
                tag1.tagName = "prueba";
                List<Tag> list_tags = new List<Tag>();
                list_tags.Add(tag1);

                productCommentService.TagProductComment(productComments[0].CommentId, list_tags);

                productComments = productCommentService.FindByProductId(productId);

                Assert.AreEqual(list_tags[0], productComments[0].Tags[0]);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }
    }
}