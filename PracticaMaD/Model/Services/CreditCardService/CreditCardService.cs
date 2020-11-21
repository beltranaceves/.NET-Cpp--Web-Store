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
        public void AddCard(long clientId, CreditCardDetails newCard)
        {
             var Client = ClientDao.Find(clientId);

            try
            {
                CreditCardDao.FindByCreditCardNumber(newCard.CardNumber);
                throw new DuplicateInstanceException(newCard.CardNumber,
                    typeof(CreditCard).FullName);

            } catch (InstanceNotFoundException)
            {
                
                CreditCard creditCard = new CreditCard();

                creditCard.cardNumber = newCard.CardNumber;
                creditCard.cardType = newCard.CardType;
                creditCard.verificationCode = newCard.VerificationCode;
                creditCard.expeditionDate = newCard.ExpeditionDate;
                creditCard.clientId = Client.clientId;
                
                if (!Client.CreditCard.Any())
                    creditCard.defaultCard = true;
                else
                    creditCard.defaultCard = false;
                
                CreditCardDao.Create(creditCard);
            }
        }

            public CreditCardDetails GetClientDefaultCard(long clientId)
        {
            CreditCardDetails defaultCard = null;
            Client client = null;
            try
            {
                client = ClientDao.Find(clientId);
            } catch (InstanceNotFoundException e)
            {
                throw new InstanceNotFoundException(clientId,"Client not found");
            }
            List<CreditCard> clientCards = client.CreditCard.ToList();
            if (clientCards != null) {
                for (int i = 0; i < clientCards.Count; i++)
                {
                    if (clientCards.ElementAt(i).defaultCard)
                    {
                        string cardNumber = clientCards.ElementAt(i).cardNumber;
                        string cardType = clientCards.ElementAt(i).cardType;
                        long verificationCode = clientCards.ElementAt(i).verificationCode;
                        String expirationDate = clientCards.ElementAt(i).expeditionDate;
                        bool DC = clientCards.ElementAt(i).defaultCard;
                        long cId = clientCards.ElementAt(i).clientId;
                        
                        defaultCard = new CreditCardDetails(cardNumber, cardType, verificationCode, expirationDate, DC,cId);
                    }
                }
            }
            return defaultCard;
        }


        [Transactional]
        public void SelectDefaultCard(long clientId, long cardID)
        {
            Client client = null;
            CreditCard card = null;
            try
            {
                client = ClientDao.Find(clientId);
            } catch (InstanceNotFoundException e)
            {
                throw new InstanceNotFoundException(clientId,"Client not found");
            }

            List<CreditCard> clientCards = client.CreditCard.ToList<CreditCard>();

            for (int i = 0; i < clientCards.Count; i++)
            {
                if (clientCards.ElementAt(i).defaultCard == true)
                {
                    clientCards.ElementAt(i).defaultCard = false;
                    CreditCardDao.Update(clientCards.ElementAt(i));
                }
            }
            try
            {

                card = CreditCardDao.Find(cardID);
            } catch(InstanceNotFoundException e)
            {
                throw new InstanceNotFoundException(cardID, "Card not found");
            }
            card.defaultCard = true;
            CreditCardDao.Update(card);
        }


        [Transactional]
        public List<CreditCardDetails> GetClientCards(long clientId)
        {

            List<CreditCardDetails> clientCards = new List<CreditCardDetails>();
            
            List<CreditCard> cards = null;
            Client client = null;


            try
            {
                client = ClientDao.Find(clientId);
            }
            catch (InstanceNotFoundException)
            {
                throw new InstanceNotFoundException(clientId,"Client not found");
            }

            cards = client.CreditCard.ToList();
            
            int  j= 0;

            for (int i = 0; i < cards.Count; i++)
            {
                if (j == cards.Count)
                    break;

                        string cardNumber = cards.ElementAt(i).cardNumber;
                        string cardType = cards.ElementAt(i).cardType;
                        long verificationCode = cards.ElementAt(i).verificationCode;
                        String expirationDate = cards.ElementAt(i).expeditionDate;
                        bool defaultCard = cards.ElementAt(i).defaultCard;
                        long cId = cards.ElementAt(i).clientId;
                               
                clientCards.Add(new CreditCardDetails(cardNumber, cardType, verificationCode, expirationDate, defaultCard,cId));
                
                j++;
            }
            return clientCards;
        }
 
    }

}
