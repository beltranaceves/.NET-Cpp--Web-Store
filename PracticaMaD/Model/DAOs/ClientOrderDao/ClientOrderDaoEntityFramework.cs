using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao
{
    public class ClientOrderDaoEntityFramework :
        GenericDaoEntityFramework<ClientOrder, Int64>, IClientOrderDao
    {
        public List<ClientOrder> FindByClientId(long clientId, int startIndex, int count)
        {
            List<ClientOrder> clientOrdersList = null;

            DbSet<ClientOrder> clientOrders = Context.Set<ClientOrder>();

            var result =
                (from c in clientOrders
                 where c.clientId == clientId
                 select c).OrderBy(c => c.orderDate).Skip(startIndex).Take(count).ToList();

            clientOrdersList = result;

            return clientOrdersList;
        }
    }
}