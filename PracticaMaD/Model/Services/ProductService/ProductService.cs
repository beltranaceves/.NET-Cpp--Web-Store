using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using System;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using System.Runtime.Caching;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    public class ProductService : IProductService
    {
        private MemoryCache _Cache = new MemoryCache("cache");
        public MemoryCache Cache { get => _Cache; }

        [Inject]
        public IProductDao ProductDao { private get; set; }

        [Inject]
        public ICategoryDao CategoryDao { private get; set; }

        #region IProductService Members

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails FindProductDetails(long productId)
        {
            Product product = ProductDao.Find(productId);

            ProductDetails productDetails = new ProductDetails(product.productName, product.price, product.registerDate, product.stock, product.categoryId);
            return productDetails;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateProduct(long productId, Product updatedProduct)
        {
            Product product =
                ProductDao.Find(productId);

            product.productName = updatedProduct.productName;
            product.price = updatedProduct.price;
            product.registerDate = updatedProduct.registerDate;
            product.stock = updatedProduct.stock;
            product.categoryId = updatedProduct.categoryId;
            //updatedProduct.productId = productId;
            ProductDao.Update(product);
        }

        [Transactional]
        public List<Product> FindProductByProductNameKeyword(String keyword)
        {
            List<Product> products = ProductDao.FindByProductNameKeyword(keyword);
            var item = new CacheItem("keyword", products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);
            return products;
        }

        [Transactional]
        public List<Product> FindProductByProductNameKeywordAndCategory(String keyword, long categoryId)
        {
            Category category = CategoryDao.Find(categoryId);

            List<Product> products = ProductDao.FindByProductNameKeywordAndCategory(keyword, category);
            var item = new CacheItem("keyword" + categoryId.ToString(), products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);
            return products;
        }

        [Transactional]
        public List<Product> FindProductByCategory(long categoryId)
        {
            Category category = CategoryDao.Find(categoryId);

            List<Product> products = ProductDao.FindByCategory(category);
            var item = new CacheItem(categoryId.ToString(), products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);
            return products;
        }

        #endregion IProductService Members
    }
}