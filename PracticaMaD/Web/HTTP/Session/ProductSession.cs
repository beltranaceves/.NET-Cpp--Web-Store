using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Es.Udc.DotNet.PracticaMad.Web.HTTP.Session
{
    public class ProductSession
    {
        private long productId;
        private String productName;

        public long ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public String ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
    }
}