using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao
{
    public class ClientOrderLineDaoEntityFramework :
        GenericDaoEntityFramework<ClientOrderLine, Int64>, IClientOrderLineDao
    {
        public List<ClientOrderLine> FindOrderLines(long orderId)
        {
            List<ClientOrderLine> lineList = null;

            DbSet<ClientOrderLine> clientOrderLine = Context.Set<ClientOrderLine>();

            var result =
                (from o in clientOrderLine
                 where o.orderId == orderId
                 select o).ToList();

            lineList = result;

            return lineList;
        }

    }
}