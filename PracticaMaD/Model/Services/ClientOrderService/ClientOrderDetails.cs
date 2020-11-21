using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClienOrderService
{
    [Serializable()]
    public class ClientOrderDetails
    {
        public long OrderId { get; }
        public System.DateTime OrderDate { get; }
        public string OrderName { get;  }
        public Nullable<long> CreditCardId { get; }
        public string ClientOrderAddress { get;  }
        public Nullable<long> ClientId { get; set; }

        public ClientOrderDetails(long orderId, DateTime orderDate, string orderName, long creditCardId,
        string clientOrderAddress,long clientId)
        {
            this.OrderId = orderId;
            this.OrderDate = orderDate;
            this.OrderName = orderName;
            this.CreditCardId = creditCardId;
            this.ClientOrderAddress = clientOrderAddress;
            this.ClientId = clientId;
        }

       /* public OrderDetails(long orderId, long usrId, string cardNumber, int postalAddress, DateTime orderDate)
        {
            this.OrderId = orderId;
            this.UsrId = usrId;
            this.CardNumber = cardNumber;
            this.PostalAddress = postalAddress;
            this.OrderDate = orderDate;
        }*/
    }
}
