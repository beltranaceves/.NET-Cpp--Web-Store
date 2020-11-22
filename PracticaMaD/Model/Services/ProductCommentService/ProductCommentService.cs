using Es.Udc.DotNet.ModelUtil.Exceptions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using System;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentTagDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService
{
    public class ProductCommentService : IProductCommentService
    {

        [Inject]
        public IProductCommentDao ProductCommentDao { private get; set; }

        [Inject]
        public IProductCommentTagDao ProductCommentTagDao { private get; set; }

        [Inject]
        public ITagDao TagDao { private get; set; }

        public void AddProductComment(long productId, String commentText, long clientId)
        {
            ProductComment productComment = new ProductComment();

            productComment.productId = productId;
            productComment.commentText = commentText;
            productComment.commentDate = System.DateTime.Now;
            productComment.clientId = clientId;

            ProductCommentDao.Create(productComment);

        }

        public List<ProductComment> FindByProductId(long productId)
        {
            List<ProductComment> productComments = ProductCommentDao.FindByProductId(productId);
            List<Tag> tags = new List<Tag>();
            foreach (ProductComment productComment in productComments)
            {
                List<ProductCommentTag> productCommentTags =
                    ProductCommentTagDao.FindByProductCommentId(productComment.commentId);
                foreach (ProductCommentTag productCommentTag in productCommentTags)
                {
                    tags.Add(TagDao.Find(productCommentTag.tagId));
                }
                productComment.Tags = tags;
            }

            return productComments;
        }

        public void TagProductComment(long productCommentId, String tagName)
        {
            Tag tag;
            if (!TagDao.existsByTagName(tagName))
            {
                TagDao.Create(new Tag(tagName));
            }
            tag = TagDao.FindByTagName(tagName);

            ProductCommentTag productCommentTag = new ProductCommentTag(productCommentId, tag.tagId);
            if (ProductCommentTagDao.ExistsByProductCommentIdAndTagId(productCommentId, tag.tagId))
            {
                throw new DuplicateInstanceException(productCommentTag, typeof(ProductCommentTag).FullName);
            }

            ProductCommentTagDao.Create(productCommentTag);

        }

        #region IProductCommentService Members

        #endregion IProductCommentService Members
    }
}