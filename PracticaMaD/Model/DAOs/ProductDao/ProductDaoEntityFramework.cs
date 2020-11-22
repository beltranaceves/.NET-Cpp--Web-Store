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
        public List<Product> FindByKeywords(String keywords)
        {
            List<Product> productList= new List<Product>();

            DbSet<Product> products = Context.Set<Product>();
            
            
            var result =
                 (from p in products
                  where p.productName like @keywords
                  select p);

            productList = result;


            if (!productList.Any())
                throw new InstanceNotFoundException(name,
                    typeof(Product).FullName);

            return productList;
        }


        public Product FindByProductName(string ProductName)
        {
        
            DbSet<Product> products = Context.Set<Product>();

            Product product = null;

            var result =
                 (from p in products
                  where p.productName == ProductName
                  select p);

            product = result.FirstOrDefault();
            
            return product;

        }
        #endregion IProductDao Members. Specific Operations
    }

    
}
