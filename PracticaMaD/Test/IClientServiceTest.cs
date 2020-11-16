using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMad.Test
{
    /// <summary>
    /// This is a test class for IClientServiceTest and is intended to contain all IClientServiceTest
    /// Unit Tests
    /// </summary>
    [TestClass]
    public class IClientServiceTest
    {
        // Variables used in several tests are initialized here
        private const string clientLogin = "ClientLoginTest";

        private const string clientPassword = "clientPassword";
        private const string clientName = "clientName";
        private const string firstName = "name";
        private const string lastName = "lastName";
        private const string email = "user@udc.es";
        private const string language = "es";
        private const string clientAddress = "Calle coruña Nº1";
        private const string rol = "USER";
        private const long NON_EXISTENT_USER_ID = -1;
        private static IKernel kernel;
        private static IClientService clientService;
        private static IClientDao clientDao;

        private TransactionScope transaction;

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the
        /// current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// A test for RegisterClient
        /// </summary>
        [TestMethod]
        public void RegisterClientTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client and find profile
                var clientId =
                    clientService.RegisterClient(clientLogin, clientPassword,
                        new ClientDetails(clientName, firstName, lastName, email, language, clientAddress, rol));

                var client = clientDao.Find(clientId);

                // Check data
                Assert.AreEqual(clientId, client.clientId);
                Assert.AreEqual(clientLogin, client.clientLogin);
                Assert.AreEqual(PasswordEncrypter.Crypt(clientPassword), client.clientPassword);
                Assert.AreEqual(firstName, client.firstName);
                Assert.AreEqual(lastName, client.lastName);
                Assert.AreEqual(email, client.email);
                Assert.AreEqual(language, client.clientLanguage);
                Assert.AreEqual(clientAddress, client.clientAddress);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            clientDao = kernel.Get<IClientDao>();
            clientService = kernel.Get<IClientService>();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
        }

        #endregion Additional test attributes
    }
}