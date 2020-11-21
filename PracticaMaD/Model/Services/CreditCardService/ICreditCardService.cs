using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService
{
    public interface ICreditCardService
    {

        [Inject]
        ICreditCardDao CreditCardDao { set; }

        [Inject]
        IClientDao ClientDao { set; }

        [Transactional]
        void AddCard(long clientId, CreditCardDetails newCard);

        [Transactional]
        CreditCardDetails GetClientDefaultCard (long clientId);

        [Transactional]
        void SelectDefaultCard(long clientId, long cardId);

        [Transactional]
        List<CreditCardDetails> GetClientCards(long clientId);

       

     
    }
}