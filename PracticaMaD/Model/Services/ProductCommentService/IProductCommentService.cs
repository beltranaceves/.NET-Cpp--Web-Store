using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Ninject;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService
{
    public interface IProductCommentService
    {
        [Inject]
        IProductCommentDao ProductCommentDao { set; }

        [Inject]
        ITagDao TagDao { set; }

        /// <summary>
        /// Find all the comments for a product.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <returns> The product comments</returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<ProductCommentDetails> FindByProductId(long productId);

        /// <summary>
        /// Adds a comment to a product.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <param name="commentText"> The text of the comment. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void AddProductComment(long productId, String commentText, long clientId);

        /// <summary>
        /// Adds the tags to a product.
        /// </summary>
        /// <param name="productCommentId"> The productId. </param>
        /// <param name="tags"> The tags to add to the comment. </param>
        [Transactional]
        void TagProductComment(long productCommentId, List<Tag> tags);
    }
}