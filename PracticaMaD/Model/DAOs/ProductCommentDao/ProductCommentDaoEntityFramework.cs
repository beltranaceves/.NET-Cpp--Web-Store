using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao
{
    public class ProductCommentDaoEntityFramework :
        GenericDaoEntityFramework<ProductComment, Int64>, IProductCommentDao
    {
        public List<Product> FindByProduct(Product product)
        {
            #region Option 1: Using Linq.

            DbSet<ProductComment> productComment = Context.Set<ProductComment>();

            DbSet<Product> products = Context.Set<Product>();

            List<Product> result =
                (from prodComm in productComment
                 join prod in products on prodComm.productId equals prod.productId
                 where prodComm.productId == product.productId
                 select prod).ToList();
            return result;

            #endregion Option 1: Using Linq.
        }

    }
}