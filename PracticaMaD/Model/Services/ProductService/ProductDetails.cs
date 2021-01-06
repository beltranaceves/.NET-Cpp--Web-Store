using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    /// <summary>
    /// VO Class which contains the product details
    /// </summary>
    [Serializable()]
    public class ProductDetails
    {
        #region Properties Region

        public long ProductId { get; private set; }
        public String ProductName { get; private set; }

        public double Price { get; private set; }

        public System.DateTime RegisterDate { get; private set; }

        public int Stock { get; private set; }

        public string CategoryName { get; private set; }

        #endregion Properties Region

        public ProductDetails(long productId, String productName, double price, DateTime registerDate, int stock, string categoryName)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.RegisterDate = registerDate;
            this.Stock = stock;
            this.CategoryName = categoryName;
        }
    }
}