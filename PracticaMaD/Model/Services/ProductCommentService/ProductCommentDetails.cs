using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService
{
    [Serializable()]
    public class ProductCommentDetails
    {
        public long CommentId { get; set; }
        public long ProductId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public string ClientName { get; set; }

        public List<Tag> Tags { get; set; }

        public ProductCommentDetails(long commentId, long productId, string commentText, DateTime commentDate,
        string clientName, List<Tag> tags)
        {
            this.CommentId = commentId;
            this.ProductId = productId;
            this.CommentText = commentText;
            this.CommentDate = commentDate;
            this.ClientName = clientName;
            this.Tags = tags;
        }
    }
}