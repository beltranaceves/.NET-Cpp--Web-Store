using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService
{
    public class CreditCardService : ICreditCardService
    {
        [Inject]
        public IClientDao ClientDao { private get; set; }

        [Inject]
        public ICreditCardDao CreditCardDao { private get; set; }

        [Transactional]
        public void AddCard(long clientId, CreditCardDetails creditCard)
        {
            if (!ClientDao.Exists(clientId))
            {
                throw new InstanceNotFoundException(clientId, "The clien't doesnt exist");
            }
            if (CreditCardDao.ExistsByCreditCardNumberAndClientId(creditCard.CardNumber, clientId))
            {
                throw new DuplicateInstanceException(creditCard, "You Already have this CreditCard");
            }
            if (creditCard.DefaultCard)
            {
                //Comprobamos si hay alguna tarjeta por defecto y la desmarcamos como default
                CreditCard defaultCard = CreditCardDao.GetDefaultCreditCardByClientId(clientId);
                if (defaultCard != null)
                {
                    defaultCard.defaultCard = false;
                    CreditCardDao.Update(defaultCard);
                }
            }

            CreditCard newCard = new CreditCard();
            newCard.cardNumber = creditCard.CardNumber;
            newCard.cardType = creditCard.CardType;
            newCard.verificationCode = creditCard.VerificationCode;
            newCard.expeditionDate = creditCard.ExpeditionDate;
            newCard.clientId = clientId;
            newCard.defaultCard = creditCard.DefaultCard;

            if (GetClientCards(clientId).Count == 0)
                newCard.defaultCard = true;

            CreditCardDao.Create(newCard);
        }

        public CreditCardDetails GetClientDefaultCard(long clientId)
        {
            CreditCard defaultCard = CreditCardDao.GetDefaultCreditCardByClientId(clientId);
            if (defaultCard == null)
            {
                throw new InstanceNotFoundException(clientId, "You dont have default creditCard");
            }

            return new CreditCardDetails(defaultCard.cardNumber, defaultCard.cardType, defaultCard.verificationCode,
                    defaultCard.expeditionDate, defaultCard.defaultCard, defaultCard.clientId);
        }

        [Transactional]
        public void SelectDefaultCard(long clientId, long cardID)
        {
            //Comprobamos si hay alguna tarjeta por defecto y la desmarcamos como default
            CreditCard defaultCard = CreditCardDao.GetDefaultCreditCardByClientId(clientId);
            if (defaultCard != null)
            {
                defaultCard.defaultCard = false;
                CreditCardDao.Update(defaultCard);
            }

            CreditCard creditCard = CreditCardDao.Find(cardID);
            creditCard.defaultCard = true;
            CreditCardDao.Update(creditCard);
        }

        [Transactional]
        public List<CreditCardDetails> GetClientCards(long clientId)
        {
            List<CreditCardDetails> clientCards = new List<CreditCardDetails>();

            List<CreditCard> cards = null;
            Client client = null;

            client = ClientDao.Find(clientId);

            if (client == null)
            {
                throw new InstanceNotFoundException(clientId, "Client not found");
            }

            cards = client.CreditCard.ToList();

            foreach (CreditCard creditCard in cards)
            {
                clientCards.Add(new CreditCardDetails(creditCard.cardNumber, creditCard.cardType, creditCard.verificationCode, creditCard.expeditionDate, creditCard.defaultCard, creditCard.clientId));
            }
            return clientCards;
        }


        [Transactional]
        public CreditCard GetCardFromNumber(string cardNumber)
        {
            CreditCard card = CreditCardDao.FindByCreditCardNumber(cardNumber);

            return card;

        }

    }
}