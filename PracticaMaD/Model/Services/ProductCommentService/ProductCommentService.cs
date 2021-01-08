using Es.Udc.DotNet.ModelUtil.Exceptions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using System;
using System.Linq;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService
{
    public class ProductCommentService : IProductCommentService
    {
        [Inject]
        public IProductCommentDao ProductCommentDao { private get; set; }

        [Inject]
        public IProductDao ProductDao { private get; set; }

        [Inject]
        public IClientDao ClientDao { private get; set; }

        [Inject]
        public ITagDao TagDao { private get; set; }

        [Transactional]
        public ProductCommentBlock FindByProductId(long productId, int startIndex, int count)
        {
            List<ProductComment> productComments = ProductCommentDao.FindByProductId(productId, startIndex, count + 1);
            List<ProductCommentDetails> productCommentsDetails = new List<ProductCommentDetails>();
            foreach (ProductComment p in productComments)
            {
                productCommentsDetails.Add(new ProductCommentDetails(p.commentId, p.productId, p.commentText, p.commentDate, p.Client.clientLogin, p.Tag.ToList()));
            }
            bool existMoreProductsComments = (productCommentsDetails.Count == count + 1);

            if (existMoreProductsComments)
                productComments.RemoveAt(count);

            return new ProductCommentBlock(productCommentsDetails, existMoreProductsComments);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductCommentDetails FindProductDetailsByProdIdAndClientID(long prodId, long clientId)
        {
            ProductComment comment = ProductCommentDao.FindByProdIdAndClientId(prodId, clientId);
            if (comment == null)
            {
                throw new InstanceNotFoundException(clientId, "Dont have any comment to edit");
            }
            Client client = ClientDao.Find(comment.clientId);
            return new ProductCommentDetails(comment.commentId, comment.productId, comment.commentText, System.DateTime.Now, client.clientLogin, comment.Tag.ToList());
        }

        [Transactional]
        public ProductComment AddProductComment(long productId, String commentText, long clientId)
        {
            ProductComment productComment = new ProductComment();

            productComment.productId = ProductDao.Find(productId).productId;
            productComment.commentText = commentText;
            productComment.commentDate = System.DateTime.Now;
            productComment.clientId = clientId;

            ProductCommentDao.Create(productComment);

            return productComment;
        }

        [Transactional]
        public void TagProductComment(long productCommentId, List<Tag> tags)
        {
            ProductComment comment = ProductCommentDao.Find(productCommentId);

            foreach (Tag tag in tags)
            {
                if (!TagDao.existsByTagName(tag.tagName))
                {
                    tag.timesUsed = 1;
                    TagDao.Create(tag);
                }
                else
                {
                    tag.timesUsed += 1;
                }
                comment.Tag.Add(tag);
            }
            ProductCommentDao.Update(comment);
        }

        [Transactional]
        public ProductCommentDetails EditProductComment(long commentId, ProductCommentDetails productCommentDetails)
        {
            ProductComment productComment = ProductCommentDao.FindById(commentId);

            if (productComment == null)
            {
                throw new InstanceNotFoundException(commentId, "No se encuentra el comentario que quieres editar");
            }

            foreach (Tag t in productCommentDetails.Tags)
            {
                if (!productComment.Tag.Contains(t))
                {
                    t.timesUsed += 1;
                }
            }
            foreach (Tag t in productComment.Tag)
            {
                if (!productCommentDetails.Tags.Contains(t))
                {
                    t.timesUsed -= 1;
                    t.ProductComment.Remove(productComment);
                }
            }
            Client client = ClientDao.FindByLogin(productCommentDetails.ClientName);
            productComment.productId = productCommentDetails.ProductId;
            productComment.commentText = productCommentDetails.CommentText;
            productComment.commentDate = System.DateTime.Now;
            productComment.clientId = client.clientId;
            productComment.Tag = productCommentDetails.Tags;

            ProductCommentDao.Update(productComment);

            return productCommentDetails;
        }

        [Transactional]
        public bool ExistCommentFromClient(long productId, long clientId)
        {
            bool existComment = ProductCommentDao.ExistByProductIdAndClientId(productId, clientId);

            return existComment;
        }

        [Transactional]
        public void RemoveComment(long commentId)
        {
            ProductCommentDao.Remove(commentId);
        }
    }
}