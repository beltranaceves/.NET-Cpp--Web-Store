using Es.Udc.DotNet.PracticaMad.Model;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Data.Entity;
using System.Transactions;
using Es.Udc.DotNet.ModelUtil.Dao;
using Ninject.Activation;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    /// <summary>
    ///This is a test class for IGenericDaoTest and is intended
    ///to contain all IGenericDaoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IGenericDaoTest
    {
        private static IKernel kernel;

        private TestContext testContextInstance;
        private Client client;
        private static IClientDao clientDao;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        #region Additional test attributes

        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            clientDao = kernel.Get<IClientDao>();
        }

        //
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            client = new Client();
            client.clientLogin = "jsmith";
            client.clientPassword = "password";
            client.firstName = "John";
            client.firstSurname = "Smith";
            client.lastSurname = "Jordan";
            client.email = "jsmith@acme.com";
            client.clientLanguage = "en";
            client.clientAddress = "County Hwy V, Hancock, WI 54943, EE. UU.";
            client.rol = "USER";

            clientDao.Create(client);
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            try
            {
                clientDao.Remove(client.clientId);
            }
            catch (Exception)
            {
            }
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void DAO_FindTest()
        {
            try
            {
                Client actual = clientDao.Find(client.clientId);

                Assert.AreEqual(client, actual, "Client found does not correspond with the original one.");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_ExistsTest()
        {
            try
            {
                bool clientExists = clientDao.Exists(client.clientId);

                Assert.IsTrue(clientExists);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DAO_NotExistsTest()
        {
            try
            {
                bool clientNotExists = clientDao.Exists(-1);

                Assert.IsFalse(clientNotExists);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void DAO_UpdateTest()
        {
            try
            {
                client.firstName = "Juan";
                client.firstSurname = "Gómez";
                client.lastSurname = "González";
                client.email = "jgonzalez@acme.es";
                client.clientLanguage = "es";
                client.clientAddress = "Calle de la Fic, Nº12";
                client.clientPassword = "contraseña";

                clientDao.Update(client);

                Client actual = clientDao.Find(client.clientId);

                Assert.AreEqual(client, actual);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Remove
        [TestMethod()]
        public void DAO_RemoveTest()
        {
            try
            {
                clientDao.Remove(client.clientId);

                bool clientExists = clientDao.Exists(client.clientId);

                Assert.IsFalse(clientExists);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        public void DAO_CreateTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Client newClient = new Client();
                newClient.clientLogin = "login";
                newClient.clientPassword = "password";
                newClient.firstName = "John";
                newClient.firstSurname = "Walden";
                newClient.lastSurname = "Smith";
                newClient.email = "john.smith@acme.com";
                newClient.clientLanguage = "en";
                newClient.clientAddress = "County Hwy V, Hancock, WI 54943, EE. UU.";
                newClient.rol = "USER";

                clientDao.Create(newClient);

                bool clientExists = clientDao.Exists(newClient.clientId);

                Assert.IsTrue(clientExists);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        ///A test for Attach
        ///</summary>
        [TestMethod()]
        public void DAO_AttachTest()
        {
            Client otherClient = clientDao.Find(client.clientId);
            clientDao.Remove(otherClient.clientId);   // removes the client created in MyTestInitialize();

            // First we get CommonContext from GenericDAO...
            DbContext dbContext = ((GenericDaoEntityFramework<Client, Int64>)clientDao).Context;

            // Check the client is not in the context now (EntityState.Detached notes that entity is not tracked by the context)
            Assert.AreEqual(dbContext.Entry(otherClient).State, EntityState.Detached);

            // If we attach the entity it will be tracked again
            clientDao.Attach(otherClient);

            // EntityState.Unchanged = entity exists in context and in DataBase with the same values
            Assert.AreEqual(dbContext.Entry(otherClient).State, EntityState.Unchanged);
        }
    }
}