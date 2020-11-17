using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.Services.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Transactions;
using System;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;

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
        private const string firstName = "name";
        private const string firstSurname = "firstSurname";
        private const string lastSurname = "lastSurname";
        private const string email = "user@udc.es";
        private const string clientLanguage = "es";
        private const string clientAddress = "Calle coruña Nº1";
        private const string rol = "USER";
        private const long NON_EXISTENT_CLIENT_ID = -1;
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
                        new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                var client = clientDao.Find(clientId);

                // Check data
                Assert.AreEqual(clientId, client.clientId);
                Assert.AreEqual(clientLogin, client.clientLogin);
                Assert.AreEqual(PasswordEncrypter.Crypt(clientPassword), client.clientPassword);
                Assert.AreEqual(firstName, client.firstName);
                Assert.AreEqual(firstSurname, client.firstSurname);
                Assert.AreEqual(lastSurname, client.lastSurname);
                Assert.AreEqual(email, client.email);
                Assert.AreEqual(clientLanguage, client.clientLanguage);
                Assert.AreEqual(clientAddress, client.clientAddress);
                Assert.AreEqual(rol, client.rol);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for registering a client that already exists in the database
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void RegisterDuplicatedClientTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client
                clientService.RegisterClient(clientLogin, clientPassword,
                    new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                // Register the same client
                clientService.RegisterClient(clientLogin, clientPassword,
                    new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        ///// <summary>
        /////A test for Login with clear password
        /////</summary>
        [TestMethod]
        public void LoginClearPasswordTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client
                var clientId = clientService.RegisterClient(clientLogin, clientPassword,
                    new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                var expected = new LoginResult(clientId, firstName,
                    PasswordEncrypter.Crypt(clientPassword), clientLanguage, clientAddress);

                // Login with clear password
                var actual =
                    clientService.Login(clientLogin,
                        clientPassword, false);

                // Check data
                Assert.AreEqual(expected, actual);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        ///// <summary>
        /////A test for Login with encrypted password
        /////</summary>
        [TestMethod]
        public void LoginEncryptedPasswordTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client
                var clientId = clientService.RegisterClient(clientLogin, clientPassword,
                   new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                var expected = new LoginResult(clientId, firstName,
                    PasswordEncrypter.Crypt(clientPassword), clientLanguage, clientAddress);

                // Login with encrypted password
                var obtained =
                    clientService.Login(clientLogin,
                        PasswordEncrypter.Crypt(clientPassword), true);

                // Check data
                Assert.AreEqual(expected, obtained);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        ///// <summary>
        /////A test for Login with incorrect password
        /////</summary>
        [TestMethod]
        [ExpectedException(typeof(IncorrectPasswordException))]
        public void LoginIncorrectPasswordTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client
                var clientId = clientService.RegisterClient(clientLogin, clientPassword,
                   new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                // Login with incorrect (clear) password
                var actual =
                    clientService.Login(clientLogin, clientPassword + "X", false);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        ///// <summary>
        /////A test for Login with a non-existing client
        /////</summary>
        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void LoginNonExistingClientTest()
        {
            // Login for a client that has not been registered
            var actual =
                clientService.Login(clientLogin, clientPassword, false);
        }

        /// <summary>
        /// A test for FindClientDetails
        /// </summary>
        [TestMethod]
        public void FindClientDetailsTest()
        {
            using (var scope = new TransactionScope())
            {
                var expected =
                   new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol);

                var clientId =
                    clientService.RegisterClient(clientLogin, clientPassword, expected);

                var obtained =
                    clientService.FindClientDetails(clientId);

                // Check data
                Assert.AreEqual(expected, obtained);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for FindClientDetails when the client does not exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindClientDetailsForNonExistingClientTest()
        {
            clientService.FindClientDetails(NON_EXISTENT_CLIENT_ID);
        }

        /// <summary>
        /// A test for UpdateClientDetails
        /// </summary>
        [TestMethod]
        public void UpdateClientDetailsTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client and update details
                var clientId = clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                var expected =
                    new ClientDetails(firstName + "X", firstSurname + "X", lastSurname + "X",
                        email + "X", "XX", "XX", "XX");

                clientService.UpdateClientDetails(clientId, expected);

                var obtained =
                    clientService.FindClientDetails(clientId);

                // Check changes
                Assert.AreEqual(expected, obtained);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for UpdateClientDetails when the client does not exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void UpdateClientDetailsForNonExistingClientTest()
        {
            using (var scope = new TransactionScope())
            {
                clientService.UpdateClientDetails(NON_EXISTENT_CLIENT_ID,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for ChangePassword
        /// </summary>
        [TestMethod]
        public void ChangePasswordTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client
                var clientId = clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                // Change password
                var newClearPassword = clientPassword + "X";
                clientService.ChangePassword(clientId, clientPassword, newClearPassword);

                // Try to login with the new password. If the login is correct, then the password
                // was successfully changed.
                clientService.Login(clientLogin, newClearPassword, false);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for ChangePassword entering a wrong old password
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IncorrectPasswordException))]
        public void ChangePasswordWithIncorrectPasswordTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register client
                var clientId = clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                // Change password
                var newClearPassword = clientPassword + "X";
                clientService.ChangePassword(clientId, clientPassword + "Y", newClearPassword);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for ChangePassword when the client does not exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void ChangePasswordForNonExistingClientTest()
        {
            clientService.ChangePassword(NON_EXISTENT_CLIENT_ID,
                clientPassword, clientPassword + "X");
        }

        /// <summary>
        /// A test to check if a valid clientLogin is found
        /// </summary>
        [TestMethod]
        public void ClientExistsForValidClient()
        {
            using (var scope = new TransactionScope())
            {
                // Register client
                clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, rol));

                bool clientExists = clientService.ClientExists(clientLogin);

                Assert.IsTrue(clientExists);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test to check if a not valid client clientLogin is found
        /// </summary>
        [TestMethod]
        public void ClientExistsForNotValidClient()
        {
            using (var scope = new TransactionScope())
            {
                String invalidClientLogin = clientLogin + "_someFakeClientSuffix";

                bool clientExists = clientService.ClientExists(invalidClientLogin);

                Assert.IsFalse(clientExists);

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