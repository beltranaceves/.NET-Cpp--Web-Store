using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    /// <summary>
    /// VO Class which contains the product details
    /// </summary>
    [Serializable()]
    public class MusicDetails : ProductDetails
    {
        #region Properties Region


        public String Artist { get; private set; }

        public String Title { get; private set; }

        public String Genere { get; private set; }

        public String Type { get; private set; }

        #endregion Properties Region

        public MusicDetails(long productId, String productName, double price, DateTime registerDate, int stock, string categoryName, 
            String artist, String title, String genere, string type) : base(productId, productName, price, registerDate, stock, categoryName)
        {
            this.Artist = artist;
            this.Title = title;
            this.Genere = genere;
            this.Type = type;
        }
    }
}