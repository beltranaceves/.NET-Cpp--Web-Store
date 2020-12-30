using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderLineService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Ninject;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model;

namespace Es.Udc.DotNet.PracticaMaD.Model.Service.ClientOrderService
{
    public interface IClientOrderService
    {
        [Inject]
        IClientDao ClientDao { set; }

        [Inject]
        IProductDao ProductDao { set; }

        [Inject]
        ICreditCardDao CreditCardDao { set; }

        [Inject]
        IClientOrderDao ClientOrderDao { set; }

        [Inject]
        IClientOrderLineDao ClientOrderLineDao { set; }

        [Transactional]
        List<ClientOrder> GetClientOrders(long clientId, int startIndex, int count);

        [Transactional]
        int GetNumberOfOrdersByClient(long clientId);

        [Transactional]
        ClientOrderDetails FindOrder(long orderId);

        [Transactional]
        long CreateOrder(long clientId, long cardId, string orderName, string clientOrderAddress, List<ClientOrderLineDetails> orderLine);
    }
}