using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDAO
{
    /// <summary>
    /// Specific Operations for Client
    /// </summary>
    public class CreditCardDaoEntityFramework :
        GenericDaoEntityFramework<CreditCard, Int64>, ICreditCardDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>\
        public CreditCardDaoEntityFramework()
        {
        }

        #endregion Public Constructors

        // TODO: Quitamos esto y lo ponemos en el servicio
        public Boolean isValidCard(string cardNumber)
        {
            return cardNumber.Length == 16;
        }
    }
}