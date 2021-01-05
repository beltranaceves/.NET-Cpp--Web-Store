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

        /// <summary>
        /// Count all the products of the search.
        /// </summary>
        /// <param name="keyword">The product name keyword. </param>
        /// <returns> The number of products </returns>
        [Transactional]
        public int NumberOfProductsSearched(string keyword)
        {
            int numberOfProduct = ProductDao.CountByProductNameKeywordAndCategory(keyword);
            return numberOfProduct;
        }

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
        public ProductDetails UpdateProduct(long productId, ProductDetails updatedProduct)
        {
            Product product =
                ProductDao.Find(productId);

            product.productName = updatedProduct.ProductName;
            product.price = updatedProduct.Price;
            product.registerDate = updatedProduct.RegisterDate;
            product.stock = updatedProduct.Stock;
            product.categoryId = updatedProduct.CategoryId;
            //updatedProduct.productId = productId;
            ProductDao.Update(product);

            return new ProductDetails(product.productName, product.price, product.registerDate, product.stock, product.categoryId);
        }

        [Transactional]
        public ProductBlock FindProductByProductNameKeyword(string keyword, int startIndex, int count)
        {
            List<Product> products = ProductDao.FindByProductNameKeyword(keyword, startIndex, count + 1);
            var item = new CacheItem("keyword", products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);

            bool existMoreProducts = (products.Count == count + 1);

            if (existMoreProducts)
                products.RemoveAt(count);

            return new ProductBlock(products, existMoreProducts);
        }

        [Transactional]
        public List<ProductDetails> FindProductByProductNameKeywordAndCategory(String keyword, long categoryId)
        {
            Category category = CategoryDao.Find(categoryId);

            List<Product> products = ProductDao.FindByProductNameKeywordAndCategory(keyword, category);
            var item = new CacheItem("keyword" + categoryId.ToString(), products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);

            List<ProductDetails> productsDetails = new List<ProductDetails>();
            foreach (Product p in products)
            {
                productsDetails.Add(new ProductDetails(p.productName, p.price, p.registerDate, p.stock, p.categoryId));
            }
            return productsDetails;
        }

        [Transactional]
        public List<ProductDetails> FindProductByCategory(long categoryId)
        {
            Category category = CategoryDao.Find(categoryId);

            List<Product> products = ProductDao.FindByCategory(category);
            var item = new CacheItem(categoryId.ToString(), products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);

            List<ProductDetails> productsDetails = new List<ProductDetails>();
            foreach (Product p in products)
            {
                productsDetails.Add(new ProductDetails(p.productName, p.price, p.registerDate, p.stock, p.categoryId));
            }
            return productsDetails;
        }

        [Transactional]
        public List<ProductDetails> FindProductByTag(string tagName, int startIndex, int count)
        {
            List<Product> products = ProductDao.FindByTag(tagName, startIndex, count);
            var item = new CacheItem(tagName, products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);

            List<ProductDetails> productsDetails = new List<ProductDetails>();
            foreach (Product p in products)
            {
                productsDetails.Add(new ProductDetails(p.productName, p.price, p.registerDate, p.stock, p.categoryId));
            }
            return productsDetails;
        }

        [Transactional]
        public Product productByName(string productName)
        {
            Product p = ProductDao.FindByProductName(productName);
            return p;
        }

        #endregion IProductService Members
    }
}