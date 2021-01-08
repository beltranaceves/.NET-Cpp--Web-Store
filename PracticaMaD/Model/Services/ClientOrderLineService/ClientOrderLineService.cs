using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMad.Model.Service.ClientOrderLineService
{
    public class ClientOrderLineService : IClientOrderLineService
    {
        [Inject]
        public IClientOrderLineDao ClientOrderLineDao { private get; set; }

        [Transactional]
        public List<ClientOrderLine> GetOrderLines(long orderId)
        {
            List<ClientOrderLine> list = ClientOrderLineDao.FindOrderLines(orderId);

            return list;
        }
    }
}