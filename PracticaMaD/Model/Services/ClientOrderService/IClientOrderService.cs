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
using System;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService
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
        ClientOrderBlock GetClientOrders(long clientId, int startIndex, int count);

        [Transactional]
        ClientOrderDetails FindOrder(long orderId);

        [Transactional]
        long CreateOrder(long clientId, string cardNumber, string orderName, string clientOrderAddress, ShoppingCart shoppingCart);
    }
}