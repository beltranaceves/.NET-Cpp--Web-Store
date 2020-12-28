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

        /// <summary>
        /// Add a new CreditCard
        /// </summary>
        /// <param name="clientId"> Id of the client owner of the card. </param>
        /// <param name="creditCardDetails"> The creditCard details. </param>
        /// <exception cref="DuplicateInstanceException"/>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void AddCard(long clientId, CreditCardDetails creditCardDetails);

        /// <summary>
        /// Gets the client default creditCard
        /// </summary>
        /// <param name="clientId"> Id of the client owner of the card. </param>
        /// <returns> The creditCard details </returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        CreditCardDetails GetClientDefaultCard(long clientId);

        /// <summary>
        /// Put a creditCard as the default one
        /// </summary>
        /// <param name="clientId"> Id of the client owner of the card. </param>
        /// <param name="cardId"> Id of the client owner of the card. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void SelectDefaultCard(long clientId, long cardId);

        /// <summary>
        /// Gets all the creditCard of the client
        /// </summary>
        /// <param name="clientId"> Id of the client owner of the card. </param>
        /// <returns> List with all the  creditCard details </returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<CreditCardDetails> GetClientCards(long clientId);
    }
}