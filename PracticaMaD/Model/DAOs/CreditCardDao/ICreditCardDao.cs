using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDAO
{
    public interface ICreditCardDao : IGenericDao<CreditCard, Int64>
    {
        /* <summary>
         * Check if the card is valid
         * </summary>
         * <param name ="cardNumber">cardNumber</param>
         * <returns> A boolean </returns>
         */

        // TODO: Quitamos esto y lo ponemos en el servicio
        Boolean isValidCard(String cardNumber);
    }
}