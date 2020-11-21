using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao
{
    /// <summary>
    /// Specific Operations for Client
    /// </summary>
    public class CreditCardDaoEntityFramework : GenericDaoEntityFramework<CreditCard, Int64>, ICreditCardDao
    {
     
         /// <summary>
        /// Finds a card by its number
        /// </summary>
        /// <param name="CreditCardNumber"></param>
        /// <returns></returns>
        /// <exception cref="InstanceNotFoundException"></exception>
     
     
        public CreditCard FindByCreditCardNumber(string CreditCardNumber)
        {
        
            DbSet<CreditCard> creditCard = Context.Set<CreditCard>();

            CreditCard card =null;

            var result =
                 (from c in creditCard
                  where c.cardNumber == CreditCardNumber
                  select c);

            card = result.FirstOrDefault();

            if (card == null)
                throw new InstanceNotFoundException(CreditCardNumber,
                    typeof(CreditCard).FullName);  
            
            return card;

        }
    }
}