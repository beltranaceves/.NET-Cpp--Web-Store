using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentTagDao
{
    public class ProductCommentTagDaoEntityFramework :
        GenericDaoEntityFramework<ProductCommentTag, Int64>, IProductCommentTagDao
    {
        public List<Product> FindByProductComment(ProductComment productComment)
        {
            #region Option 1: Using Linq.

            DbSet<ProductCommentTag> productCommentTag = Context.Set<ProductCommentTag>();

            DbSet<Product> products = Context.Set<Product>();

            List<Product> result =
                (from prodCommTag in productCommentTag
                 join prodComm in products on prodCommTag.productCommentId equals prodComm.productId
                 where prodCommTag.productCommentId == productComment.commentId
                 select prodComm).ToList();
            return result;

            #endregion Option 1: Using Linq.
        }

    }
}