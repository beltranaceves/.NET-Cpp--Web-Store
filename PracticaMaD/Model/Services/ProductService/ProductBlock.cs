using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    public class ProductBlock
    {
        public List<ProductDetails> Product { get; private set; }
        public bool ExistMoreProduct { get; private set; }

        public ProductBlock(List<ProductDetails> product, bool existMoreProduct)
        {
            this.Product = product;
            this.ExistMoreProduct = existMoreProduct;
        }
    }
}