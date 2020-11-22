using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentTagDao;
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
        IProductCommentTagDao ProductCommentTagDao { set; }

        [Inject]
        ITagDao TagDao { set; }

        /// <summary>
        /// Finds the product details.
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
        /// <param name="productComment"> The `product comment. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void AddProductComment(long productId, String commentText, long clientId);

        /// <summary>
        /// Tags a product comment.
        /// </summary>
        /// <param name="ProductCommentId"> The productId. </param>
        /// <param name="tag"> The product comment tag. </param>
        [Transactional]
        void TagProductComment(long productCommentId, String tagName);
    }
}