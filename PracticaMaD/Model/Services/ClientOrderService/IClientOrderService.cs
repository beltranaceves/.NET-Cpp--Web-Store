using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Ninject;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMaD.Model.Service.ClientOrderService
{
    public interface IClientOrderService
    {
        [Inject]
        IClientDao ClientDao {set; }

        [Inject]
        IProductDao ProductDao {set; }

        [Inject]
        ICreditCardDao CreditCardDao {set; }

        [Inject]
        IClientOrderDao ClientOrderDao {set; }
        
        [Inject]
        IClientOrderLineDao ClientOrderLineDao { set; }

        [Transactional]
        List<ClientOrderDetails> getClientOrders(long clientId);

        [Transactional]
        int GetNumberOfOrdersByClient(long usrId);

        [Transactional]
        ClientOrderDetails FindOrder(long orderId);

        [Transactional]
        long CreateOrder(long clienId, long cardId, string clientOrderAddress, List<ProductDetails> productList);

      
    }
}
