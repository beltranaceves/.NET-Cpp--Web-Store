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

        public String BookName { get; private set; }

        public String Author { get; private set; }

        public int Pages { get; private set; }

        public long ISBN { get; private set; }

        #endregion Properties Region

        public BooksDetails(long productId, String productName, double price, DateTime registerDate, int stock, string categoryName,
            String bookName, String author, int pages, long ISBN) : base(productId, productName, price, registerDate, stock, categoryName)
        {
            this.BookName = bookName;
            this.Author = author;
            this.Pages = pages;
            this.ISBN = ISBN;
        }
    }
}