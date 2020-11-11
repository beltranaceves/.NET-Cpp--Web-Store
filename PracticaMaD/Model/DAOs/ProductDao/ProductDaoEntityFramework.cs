using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.MiniPortal.Model.ProductDao
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
            List<Product> productList= null;

            DbSet<Product> products = Context.Set<Product>();

            var result =
                (from p in Product
                 where p.categoryId == category.categoryId
                 select p).ToList();

            productList = result;            

            

            if (productList == null)
                throw new InstanceNotFoundException(category.categoryId,
                    typeof(Product).productId);

            return productList;
        }

        public List<Product> findByProductNameKeyword(String keyword)
        {
            List<Product> productList= null;

            DbSet<Product> products = Context.Set<Product>();

            var result =
                (from p in Product
                 where p.productName.ToLower().Contains(keyword.ToLower())
                 select p).ToList();

            productList = result;            

            

            if (productList == null)
                throw new InstanceNotFoundException(keyword,
                    typeof(keyword));

            return productList;
        }

        public List<Product> findByProductNameKeywordAndCategory(String keyword, Category category)
        {
            List<Product> productList= null;

            DbSet<Product> products = Context.Set<Product>();

            var result =
                (from p in Product
                 where (p.productName.ToLower().Contains(keyword.ToLower()) && p.categoryId == category.categoryId)
                 select p).ToList();

            productList = result;            

            

            if (productList == null)
                throw new InstanceNotFoundException(keyword,
                    typeof(keyword));

            return productList;
        }

        #endregion IProductDao Members
    }

}
