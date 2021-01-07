using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    /// <summary>
    /// VO Class which contains the product details
    /// </summary>
    [Serializable()]
    public class FilmsDetails : ProductDetails
    {
        #region Properties Region

        public String Director { get; private set; }

        public int FilmYear { get; private set; }

        public int Duration { get; private set; }

        public String Genere { get; private set; }

        #endregion Properties Region

        public FilmsDetails(long productId, String productName, double price, DateTime registerDate, int stock, string categoryName,
            String director, int filmYear, int duration, String genere) : base(productId, productName, price, registerDate, stock, categoryName)
        {
            this.Director = director;
            this.FilmYear = filmYear;
            this.Duration = duration;
            this.Genere = genere;
        }
    }
}
