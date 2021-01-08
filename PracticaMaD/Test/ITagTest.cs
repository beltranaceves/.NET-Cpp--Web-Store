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
using Es.Udc.DotNet.PracticaMad.Model.Services.TagService;
using System;
using System.Linq;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    [TestClass]
    public class ITagTest
    {
        private static IKernel kernel;

        private static ITagService tagService;
        private static ITagDao tagDao;
        private static IClientService clientService;

        private static ICategoryDao categoryDao;
        private static IProductCommentService productCommentService;

        private static IClientDao clientDao;

        private static IProductDao productDao;

        public TestContext TestContext { get; set; }

        #region Additional test attributes

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            categoryDao = kernel.Get<ICategoryDao>();
            tagDao = kernel.Get<ITagDao>();
            clientDao = kernel.Get<IClientDao>();
            productDao = kernel.Get<IProductDao>();
            tagService = kernel.Get<ITagService>();
            clientService = kernel.Get<IClientService>();
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

        [TestMethod()]
        public void GetAllTags()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Tag tag1 = new Tag();
                tag1.tagName = "Prueba";
                tag1.timesUsed = 0;
                Tag tag2 = new Tag();
                tag2.tagName = "Prueba2";
                tag2.timesUsed = 0;
                tagDao.Create(tag1);
                tagDao.Create(tag2);
                List<Tag> expected = new List<Tag>();
                expected.Add(tag1);
                expected.Add(tag2);

                List<Tag> obtained = tagService.GetAllTags();
                Assert.AreEqual(expected[0], obtained[0]);
                Assert.AreEqual(expected[1], obtained[1]);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        public void FindByTagNameTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Tag tag1 = new Tag();
                tag1.tagName = "Prueba";
                tag1.timesUsed = 0;
                Tag tag2 = new Tag();
                tag2.tagName = "Prueba2";
                tag2.timesUsed = 0;
                tagDao.Create(tag1);
                tagDao.Create(tag2);

                Tag obtained = tagService.FindTagByName("Prueba2");
                Assert.AreEqual(tag2, obtained);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        public void GetMoreUsedTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Tag tag1 = new Tag();
                tag1.tagName = "Prueba";
                tag1.timesUsed = 2;
                Tag tag2 = new Tag();
                tag2.tagName = "Prueba2";
                tag2.timesUsed = 1;
                Tag tag3 = new Tag();
                tag3.tagName = "Prueba3";
                tag3.timesUsed = 0;
                Tag tag4 = new Tag();
                tag4.tagName = "Prueba4";
                tag4.timesUsed = 4;
                Tag tag5 = new Tag();
                tag5.tagName = "Prueba5";
                tag5.timesUsed = 5;
                Tag tag6 = new Tag();
                tag6.tagName = "Prueba6";
                tag6.timesUsed = 2;
                tagDao.Create(tag1);
                tagDao.Create(tag2);
                tagDao.Create(tag3);
                tagDao.Create(tag4);
                tagDao.Create(tag5);
                tagDao.Create(tag6);
                List<Tag> expected = new List<Tag>();
                expected.Add(tag5);
                expected.Add(tag4);
                expected.Add(tag6);
                expected.Add(tag1);
                expected.Add(tag2);
                List<Tag> obtained = tagService.GetMoreUsedTags();
                Assert.AreEqual(expected[0], obtained[0]);
                Assert.AreEqual(expected[1], obtained[1]);
                Assert.AreEqual(expected[2], obtained[2]);
                Assert.AreEqual(expected[3], obtained[3]);
                Assert.AreEqual(expected[4], obtained[4]);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void CreateDuplicateTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Tag tag1 = new Tag();
                tag1.tagName = "Prueba";
                tag1.timesUsed = 0;
                tagDao.Create(tag1);

                Tag obtained = tagService.Create("Prueba");

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }
    }
}