using Es.Udc.DotNet.ModelUtil.Exceptions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using System;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService
{
    public class ProductCommentService : IProductCommentService
    {
        [Inject]
        public IProductCommentDao ProductCommentDao { private get; set; }

        [Inject]
        public IProductDao ProductDao { private get; set; }

        [Inject]
        public ITagDao TagDao { private get; set; }

        public List<ProductCommentDetails> FindByProductId(long productId)
        {
            List<ProductCommentDetails> productComments = ProductCommentDao.FindByProductId(productId);

            return productComments;
        }

        public void AddProductComment(long productId, String commentText, long clientId)
        {
            ProductComment productComment = new ProductComment();

            productComment.productId = ProductDao.Find(productId).productId;
            productComment.commentText = commentText;
            productComment.commentDate = System.DateTime.Now;
            productComment.clientId = clientId;

            ProductCommentDao.Create(productComment);
        }

        public void TagProductComment(long productCommentId, List<Tag> tags)
        {
            ProductComment comment = ProductCommentDao.Find(productCommentId);

            foreach (Tag tag in tags)
            {
                if (!TagDao.existsByTagName(tag.tagName))
                {
                    TagDao.Create(tag);
                }
                comment.Tag.Add(tag);
            }
            ProductCommentDao.Update(comment);
        }
    }
}