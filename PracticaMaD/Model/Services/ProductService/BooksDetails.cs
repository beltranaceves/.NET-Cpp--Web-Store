using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    /// <summary>
    /// VO Class which contains the product details
    /// </summary>
    [Serializable()]
    public class BooksDetails : ProductDetails
    {
        #region Properties Region


        public String Author { get; private set; }

        public int Pages { get; private set; }

        public long ISBN { get; private set; }

        public String Editorial { get; private set; }

        #endregion Properties Region

        public BooksDetails(long productId, String productName, double price, DateTime registerDate, int stock, string categoryName,
           String author, int pages, long ISBN, String editorial) : base(productId, productName, price, registerDate, stock, categoryName)
        {
            this.Author = author;
            this.Pages = pages;
            this.ISBN = ISBN;
            this.Editorial = editorial;
        }
    }
}