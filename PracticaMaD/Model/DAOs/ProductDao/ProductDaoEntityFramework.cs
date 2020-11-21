using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao
{
    /// <summary>
    /// Specific Operations for Product
    /// </summary>
    public class ProductDaoEntityFramework : GenericDaoEntityFramework<Product, Int64>, IProductDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        public ProductDaoEntityFramework()
        {
        }

        #endregion Public Constructors

        #region IProductDao Members. Specific Operations

        /// <summary>
        /// Finds all products by categoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>A list of Product</returns>
        public List<Product> findByCategory(Category category)
        {
            List<Product> productList = null;

            DbSet<Product> products = Context.Set<Product>();

            var result =
                (from p in products
                 where p.categoryId == category.categoryId
                 select p).ToList();

            productList = result;

            if (productList == null)
                throw new InstanceNotFoundException(category.categoryId,
                    typeof(Product).FullName);

            return productList;
        }

        public List<Product> findByProductNameKeyword(String keyword)
        {
            List<Product> productList = null;

            DbSet<Product> products = Context.Set<Product>();

            var result =
                (from p in products
                 where p.productName.ToLower().Contains(keyword.ToLower())
                 select p).ToList();

            productList = result;

            if (productList == null)
                throw new InstanceNotFoundException(keyword,
                    typeof(Product).FullName);

            return productList;
        }

        public List<Product> findByProductNameKeywordAndCategory(String keyword, Category category)
        {
            List<Product> productList = null;

            DbSet<Product> products = Context.Set<Product>();

            var result =
                (from p in products
                 where (p.productName.ToLower().Contains(keyword.ToLower()) && p.categoryId == category.categoryId)
                 select p).ToList();

            productList = result;

            if (productList == null)
                throw new InstanceNotFoundException(keyword,
                    typeof(Product).FullName);

            return productList;
        }
        /// <summary>
        /// Finds a card by its number
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        /// <exception cref="InstanceNotFoundException"></exception>


        public Product FindByProductName(string ProductName)
        {
        
            DbSet<Product> products = Context.Set<Product>();

            Product product = null;

            var result =
                 (from p in products
                  where p.productName == ProductName
                  select p);

            product = result.FirstOrDefault();

            if (product == null)
                throw new InstanceNotFoundException(ProductName,
                    typeof(Product).FullName);  
            
            return product;

        }
        #endregion IProductDao Members. Specific Operations
    }

    
}
