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
        public System.DateTime OrderDate { get; }
        public string OrderName { get;  }
        public long CreditCardId { get; }
        public string ClientOrderAddress { get;  }
        public long ClientId { get; set; }

        public ClientOrderDetails(DateTime orderDate, string orderName, long creditCardId,
        string clientOrderAddress,long clientId)
        {
            this.OrderDate = orderDate;
            this.OrderName = orderName;
            this.CreditCardId = creditCardId;
            this.ClientOrderAddress = clientOrderAddress;
            this.ClientId = clientId;
        }

        public ClientOrderDetails(long clientId, long creditCardId, string clientOrderAddress, DateTime orderDate)
        {
            this.ClientId = clientId;
            this.CreditCardId = creditCardId;
            this.ClientOrderAddress = clientOrderAddress;
            this.OrderDate = orderDate;
        }
    }
}
