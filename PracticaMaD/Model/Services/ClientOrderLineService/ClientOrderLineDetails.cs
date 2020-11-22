using System;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderLineService

{
    /// <summary>
    /// VO Class which contains the orderline details
    /// </summary>
    [Serializable()]
    public class ClientOrderLineDetails
    {
        #region Properties region

        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        #endregion Properties region

        public ClientOrderLineDetails(long productId, int quantity, double price)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}