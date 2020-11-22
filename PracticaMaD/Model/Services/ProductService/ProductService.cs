using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.Common;
using System;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    public class ProductService : IProductService
    {
        [Inject]
        public IProductDao ProductDao { private get; set; }

        [Inject]
        public ICategoryDao CategoryDao { private get; set; }

        [Inject]
        public ICategoryDao ClientOrderDao { private get; set; }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails FindProduct(long productId)
        {
            Product product = ProductDao.Find(productId);

            var productDetails = new ProductDetails(product.productName,
            product.price, product.registerDate, product.stock, product.categoryId);

            return productDetails;
        }

        [Transactional]
        public List<ProductDetails> FindByKeywords(string keywords)
        {
            List<ProductDetails> products = new List<ProductDetails>();

            try
            {
                List<Product> productList = ProductDao.FindByKeywords(keywords);

                for (int i = 0; i < productList.Count; i++)
                {
                    long productId = productList.ElementAt(i).ProductId;
                    string productName = productList.ElementAt(i).ProductName;
                    long categoryId = productList.ElementAt(i).CategoryId;
                    DateTime registerDate = productList.ElementAt(i).RegisterDate;
                    double prize = productList.ElementAt(i).Price;
                    int stock = productList.ElementAt(i).Stock;

                    products.Add(new ProductDetails(productName, price, registerDate
                    , stock, categoryId));
                }
            }
            catch (InstanceNotFoundException e)
            {
            }
            return products;
        }

        [Transactional]
        public List<ProductDetails> FindByTag(long tagId)
        {
            List<ProductDetails> products = new List<ProductDetails>();
            List<Product> productList = TagDao.Find(tagId).Products.ToList<Product>();

            int j = 0;

            for (int i = 0; i < productList.Count; i++)
            {
                if (j == productList.Count)
                    break;
                long productId = productList.ElementAt(i).ProductId;
                string productName = productList.ElementAt(i).ProductName;
                long categoryId = productList.ElementAt(i).CategoryId;
                DateTime registerDate = productList.ElementAt(i).RegisterDate;
                double prize = productList.ElementAt(i).Price;
                int stock = productList.ElementAt(i).Stock;
                products.Add(new ProductDetails(productName, price, registerDate
                , stock, categoryId));
                j++;
            }
            return products;
        }

        [Transactional]
        public List<ProductDetails> GetClientOrderLineProductsByClientOrderId(long orderId)
        {
            ClientOrder order = ClientOrderDao.Find(orderId);
            List<ProductDetails> productsDetails = new List<ProductDetails>();

            for (int i = 0; i < order.OrderLines.Count; i++)
            {
                Product p = ProductDao.Find(order.ClientOrderLines.ElementAt(i).productId);
                ProductDetails productDetails = new ProductDetails(p.productname, p.price, p.registerDate,
                p.stock, p.categoryId);
            }

            return productsDetails;
        }
    }
}