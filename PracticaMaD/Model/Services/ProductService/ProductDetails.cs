using System;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    /// <summary>
    /// VO Class which contains the product details
    /// </summary>
    [Serializable()]
    public class ProductDetails
    {
        #region Properties Region

        public String ProductName { get; set; }

        public double Price { get; set; }

        public System.DateTime RegisterDate { get; set; }

        public int Stock { get; set; }

        public long CategoryId { get; set; }

        #endregion Properties Region

        public ProductDetails(String productName, double price, DateTime registerDate, int stock, long categoryId)
        {
            this.ProductName = productName;
            this.Price = price;
            this.RegisterDate = registerDate;
            this.Stock = stock;
            this.CategoryId = categoryId;
        }
    }
}