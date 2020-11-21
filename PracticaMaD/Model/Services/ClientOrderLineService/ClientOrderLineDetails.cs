using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderLineService

{
    [Serializable()]
    public class ClientOrderLineDetails
    {
        #region Properties region
        private long OrderId;

        private long ProductId;

        private int Quantity;

        private double Price;

        #endregion
        public ClientOrderLineDetails(long orderId, long productId,int quantity, double price)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}


