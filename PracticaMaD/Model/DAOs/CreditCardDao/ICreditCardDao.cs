using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao
{
    public interface ICreditCardDao : IGenericDao<CreditCard, Int64>
    {
        CreditCard FindByCreditCardNumber(string CreditCardNumber);

    }
}