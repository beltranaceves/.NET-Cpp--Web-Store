using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao
{
    public interface IClientOrderDao : IGenericDao<ClientOrder, Int64>
    {
        List<ClientOrder> FindByClientId(long clientId, int startIndex, int count);
    }
}