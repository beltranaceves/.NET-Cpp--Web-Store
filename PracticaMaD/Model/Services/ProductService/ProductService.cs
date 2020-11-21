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

        #region IProductService Members

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public Product FindProduct(long productId)
        {
            Product product = ProductDao.Find(productId);

            return product;
        }
     

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateProduct(long productId, Product updatedProduct)
        {
            Product product =
                ProductDao.Find(productId);

            product.productName = updatedProduct.productName;
            product.price= updatedProduct.price;
            product.registerDate= updatedProduct.registerDate;
            product.stock= updatedProduct.stock;
            product.categoryId= updatedProduct.categoryId;
            updatedProduct.productId = productId;
            ProductDao.Update(updatedProduct);
        }


        [Transactional]
        public List<Product> FindProductByProductNameKeyword(String keyword) {
            List<Product> products = ProductDao.findByProductNameKeyword(keyword); 
            return products;
        }

        [Transactional]
        public List<Product> FindProductByProductNameKeywordAndCategory(String keyword, long categoryId) {

            Category category = CategoryDao.Find(categoryId);

            List<Product> products = ProductDao.findByProductNameKeywordAndCategory(keyword, category); 
            return products;
        }

        [Transactional]
        public List<Product> FindProductByCategory(long categoryId) {

            Category category = CategoryDao.Find(categoryId);

            List<Product> products = ProductDao.findByCategory(category); 
            return products;
        }
        #endregion IProductService Members
    }
}