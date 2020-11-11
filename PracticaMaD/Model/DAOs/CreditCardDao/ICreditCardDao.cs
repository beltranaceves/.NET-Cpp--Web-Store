using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMAD.Model.DAOs.CreditCardDAO
{
    public interface ICredirCardDao : IGenericDao<ICredirCardDao, Int64>
    {
        /* <summary>
         * Check if the card is valid
         * </summary>
         * <param name ="cardNumber">cardNumber</param>
         * <returns> A boolean </returns>
         */
        Boolean isValidCard(String cardNumber);
    }
}