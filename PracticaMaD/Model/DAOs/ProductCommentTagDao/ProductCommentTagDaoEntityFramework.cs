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
        public List<ProductCommentTag> FindByProductCommentId(long productCommentId)
        {
            #region Option 1: Using Linq.

            DbSet<ProductCommentTag> productCommentTags = Context.Set<ProductCommentTag>();

            List<ProductCommentTag> result =
                (from prodCommTag in productCommentTags
                 where prodCommTag.productCommentId == productCommentId
                 select prodCommTag).ToList();
            return result;

            #endregion Option 1: Using Linq.
        }

        public Boolean ExistsByProductCommentIdAndTagId(long productCommentId, long tagId)
        {
            ProductCommentTag productCommentTag = null;

            DbSet<ProductCommentTag> productCommentTags = Context.Set<ProductCommentTag>();

            var result =
                (from p in productCommentTags
                 where (p.commentId == productCommentId && p.tagId == tagId)
                 select p);

            productCommentTag = result.FirstOrDefault();

            return (productCommentTag.commentId == productCommentId && productCommentTag.tagId == tagId);
        }
    }
}