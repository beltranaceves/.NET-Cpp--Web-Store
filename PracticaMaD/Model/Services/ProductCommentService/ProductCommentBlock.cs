using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService
{
    public class ProductCommentBlock
    {
        public List<ProductCommentDetails> ProductComment { get; private set; }
        public bool ExistMoreProductComment { get; private set; }

        public ProductCommentBlock(List<ProductCommentDetails> productComment, bool existMoreProductComment)
        {
            this.ProductComment = productComment;
            this.ExistMoreProductComment = existMoreProductComment;
        }
    }
}