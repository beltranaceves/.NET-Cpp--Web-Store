using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao
{
    public class ProductCommentDaoEntityFramework :
        GenericDaoEntityFramework<ProductComment, Int64>, IProductCommentDao
    {
        public List<ProductCommentDetails> FindByProductId(long productId)
        {
            #region Option 1: Using Linq.

            DbSet<ProductComment> productComment = Context.Set<ProductComment>();
            DbSet<Tag> tag = Context.Set<Tag>();
            List<ProductComment> result =
                (from prodComm in productComment.Include("Tag")
                 where prodComm.productId == productId
                 select prodComm).ToList();
            List<ProductCommentDetails> productDetails = new List<ProductCommentDetails>();
            foreach (ProductComment product in result)
            {
                productDetails.Add(new ProductCommentDetails(product.commentId, product.productId, product.commentText, product.commentDate,
                product.clientId, product.Tag.ToList()));
            }

            return productDetails;

            #endregion Option 1: Using Linq.
        }
    }
}