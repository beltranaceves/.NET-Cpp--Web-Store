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
        /// <param name="startIndex"> The product id. </param>
        /// <param name="count"> The product id. </param>
        /// <returns> The product comments</returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductCommentBlock FindByProductId(long productId, int startIndex, int count);

        /// <summary>
        /// Find the details for a comment.
        /// </summary>
        /// <param name="prodId"> The comment id. </param>
        /// <param name="clientId"> The comment id. </param>
        /// <returns> The comments</returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductCommentDetails FindProductDetailsByProdIdAndClientID(long prodId, long clientId);

        /// <summary>
        /// Adds a comment to a product.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <param name="commentText"> The text of the comment. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductComment AddProductComment(long productId, String commentText, long clientId);

        /// <summary>
        /// Adds the tags to a product.
        /// </summary>
        /// <param name="productCommentId"> The productId. </param>
        /// <param name="tags"> The tags to add to the comment. </param>
        [Transactional]
        void TagProductComment(long productCommentId, List<Tag> tags);

        /// <summary>
        /// Edit a comment
        /// </summary>
        /// <param name="commentId"> The comment Id. </param>
        /// <param name="productCommentDetails"> The comment. </param>
        /// <returns> The new comment</returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductCommentDetails EditProductComment(long commentId, ProductCommentDetails productCommentDetails);

        /// <summary>
        /// See if a client comment the product
        /// </summary>
        /// <param name="productId"> The product Id. </param>
        /// <param name="clientId"> The client Id. </param>
        /// <returns> True-> exist a comment, False-> Doesnt exist the comment</returns>

        [Transactional]
        bool ExistCommentFromClient(long productId, long clientId);

        /// <summary>
        /// Remove a comment
        /// </summary>
        /// <param name="commentId"> The commentId id. </param>
        [Transactional]
        void RemoveComment(long commentId);
    }
}