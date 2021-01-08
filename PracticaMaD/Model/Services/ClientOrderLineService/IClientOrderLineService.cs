using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Service.ClientOrderLineService
{
    public interface IClientOrderLineService
    {
        /// <summary>
        /// Get an order lines
        /// </summary>
        /// <param name="orderId"> The tag Name. </param>
        /// object to return.</param>
        [Transactional]
        List<ClientOrderLine> GetOrderLines(long orderId);
    }
}