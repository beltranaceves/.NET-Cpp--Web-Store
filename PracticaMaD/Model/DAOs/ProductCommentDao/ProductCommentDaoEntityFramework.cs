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
        public List<ProductComment> FindByProductId(long productId)
        {
            #region Option 1: Using Linq.

            DbSet<ProductComment> productComment = Context.Set<ProductComment>();

            List<ProductComment> result =
                (from prodComm in productComment
                 where prodComm.productId == productId
                 select prodComm).ToList();
            return result;

            #endregion Option 1: Using Linq.
        }

    }
}