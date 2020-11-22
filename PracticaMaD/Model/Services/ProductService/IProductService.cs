using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Ninject;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    public interface IProductService
    {
        [Inject]
        IClientOrderDao ClientOrderDao { set; }

        [Inject]
        IProductDao ProductDao { set; }

        [Inject]
        ICategoryDao CategoryDao { set; }

        [Inject]
        ITagDao TagDao { set; }

        [Transactional]
        List<ProductDetails> FindByKeywords(String keywords);

        [Transactional]
        List<ProductDetails> FindByTag(long tagId);

        [Transactional]
        ProductDetails FindProduct(long id);

        [Transactional]
        List<ProductDetails> GetClientOrderLineProductsByClientOrderId(long orderId);

    }
}