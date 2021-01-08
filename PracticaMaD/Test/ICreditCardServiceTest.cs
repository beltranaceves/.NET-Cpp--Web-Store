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

namespace Es.Udc.DotNet.PracticaMad.Test
{
    [TestClass]
    public class ICreditCardServiceTest
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

        private static ICreditCardDao creditCardDao;
        private static IClientDao clientDao;

        private static ICreditCardService creditCardService;
        private static IClientService clientService;

        public TestContext TestContext
        { get; set; }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            creditCardDao = kernel.Get<ICreditCardDao>();
            clientDao = kernel.Get<IClientDao>();
            creditCardService = kernel.Get<ICreditCardService>();
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
        public void AddCreditCardTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                var client = clientDao.Find(clientId);

                string cardNumber = "1234567890123456";
                string cardType = "Visa";
                int verificationCode = 000;
                String expeditionDate = "01/01";

                var creditCardDetails = new CreditCardDetails(cardNumber, cardType, verificationCode, expeditionDate, true, clientId);

                creditCardService.AddCard(clientId, creditCardDetails);

                var creditCard = creditCardDao.FindByCreditCardNumber(cardNumber);

                Assert.AreEqual(cardNumber, creditCard.cardNumber);
                Assert.AreEqual(clientId, creditCard.clientId);
                Assert.AreEqual(verificationCode, creditCard.verificationCode);
                Assert.AreEqual(expeditionDate, creditCard.expeditionDate);
                Assert.AreEqual(cardType, creditCard.cardType);
                Assert.AreEqual(true, creditCard.defaultCard);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void AddDuplicatedCreditCardTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                var client = clientDao.Find(clientId);

                string cardNumber = "1234567890123456";
                string cardType = "Visa";
                int verificationCode = 000;
                String expeditionDate = "01/01";

                var creditCardDetails = new CreditCardDetails(cardNumber, cardType, verificationCode, expeditionDate, true, clientId);

                creditCardService.AddCard(clientId, creditCardDetails);

                string cardNumber2 = "1234567890123456";
                string cardType2 = "Visa";
                int verificationCode2 = 000;
                String expeditionDate2 = "01/01";

                var creditCardDetails2 = new CreditCardDetails(cardNumber2, cardType2, verificationCode2, expeditionDate2, true, clientId);

                creditCardService.AddCard(clientId, creditCardDetails2);

                //transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        ///A test for ViewCardByUser
        ///</summary>
        [TestMethod()]
        public void ViewCardByUserTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Register user and find profile
                var clientId =
                  clientService.RegisterClient(clientLogin, clientPassword,
                      new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                var client = clientDao.Find(clientId);

                // Add a cards
                string cardNumber = "1234567890123456";
                string cardType = "Visa";
                int verificationCode = 000;
                String expeditionDate = "01/01";

                CreditCardDetails creditCardDetails = new CreditCardDetails(cardNumber, cardType, verificationCode, expeditionDate, true, clientId);
                creditCardService.AddCard(clientId, creditCardDetails);

                string cardNumber2 = "9876654321098765";
                string cardType2 = "MasterCard";
                int verificationCode2 = 111;
                String expeditionDate2 = "01/01";

                CreditCardDetails creditCardDetails2 = new CreditCardDetails(cardNumber2, cardType2, verificationCode2, expeditionDate2, true, clientId);
                creditCardService.AddCard(clientId, creditCardDetails2);

                List<CreditCardDetails> cards = creditCardService.GetClientCards(clientId);
                // Check data

                Assert.AreEqual(cardNumber, cards[0].CardNumber);
                Assert.AreEqual(verificationCode, cards[0].VerificationCode);
                Assert.AreEqual(expeditionDate, cards[0].ExpeditionDate);
                Assert.AreEqual(cardType, cards[0].CardType);

                // Check data
                Assert.AreEqual(cardNumber2, cards[1].CardNumber);
                Assert.AreEqual(verificationCode2, cards[1].VerificationCode);
                Assert.AreEqual(expeditionDate2, cards[1].ExpeditionDate);
                Assert.AreEqual(cardType2, cards[1].CardType);
            }
        }

        [TestMethod()]
        public void ChangeDefaultCardTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                var client = clientDao.Find(clientId);

                // Add a cards
                string cardNumber = "1234567890123456";
                string cardType = "Visa";
                int verificationCode = 000;
                String expeditionDate = "01/01";

                CreditCardDetails creditCardDetails = new CreditCardDetails(cardNumber, cardType, verificationCode, expeditionDate, true, clientId);
                creditCardService.AddCard(clientId, creditCardDetails);

                string cardNumber2 = "9876654321098765";
                string cardType2 = "MasterCard";
                int verificationCode2 = 111;
                String expeditionDate2 = "01/01";

                CreditCardDetails creditCardDetails2 = new CreditCardDetails(cardNumber2, cardType2, verificationCode2, expeditionDate2, true, clientId);
                creditCardService.AddCard(clientId, creditCardDetails2);

                // Change the default card
                CreditCard card2 = creditCardDao.FindByCreditCardNumber(cardNumber2);
                creditCardService.SelectDefaultCard(clientId, card2.cardId);

                CreditCard card = creditCardDao.FindByCreditCardNumber(cardNumber);
                card2 = creditCardDao.FindByCreditCardNumber(cardNumber2);

                // Check data
                Assert.AreEqual(false, card.defaultCard);

                // Check data

                Assert.AreEqual(true, card2.defaultCard);
            }
        }

        /// <summary>
        ///A test for GetUserDefaultCardTest
        ///</summary>
        [TestMethod()]
        public void GetUserDefaultCardTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Register user and find profile
                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                var client = clientDao.Find(clientId);

                // Add a cards
                string cardNumber = "1234567890123456";
                string cardType = "Visa";
                int verificationCode = 000;
                String expeditionDate = "01/01";

                CreditCardDetails creditCardDetails = new CreditCardDetails(cardNumber, cardType, verificationCode, expeditionDate, true, clientId);
                creditCardService.AddCard(clientId, creditCardDetails);

                string cardNumber2 = "9876654321098765";
                string cardType2 = "MasterCard";
                int verificationCode2 = 111;
                String expeditionDate2 = "01/01";

                CreditCardDetails creditCardDetails2 = new CreditCardDetails(cardNumber2, cardType2, verificationCode2, expeditionDate2, true, clientId);
                creditCardService.AddCard(clientId, creditCardDetails2);

                CreditCardDetails defaultCard = creditCardService.GetClientDefaultCard(clientId);

                // Check the data
                Assert.AreEqual(defaultCard, creditCardDetails2);
            }
        }

        /// <summary>
        ///A test for GetUserDefaultCardTest
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void GetUserDefaultCardErrorTest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                // Register user and find profile
                var clientId =
                   clientService.RegisterClient(clientLogin, clientPassword,
                       new ClientDetails(firstName, firstSurname, lastSurname, email, clientLanguage, clientAddress, country, rol));

                var client = clientDao.Find(clientId);

                CreditCardDetails defaultCard = creditCardService.GetClientDefaultCard(clientId);
            }
        }
    }
}