using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService
{
    public class ClientOrderBlock
    {
        public List<ClientOrder> ClientOrder { get; private set; }
        public bool ExistMoreOrders { get; private set; }

        public ClientOrderBlock(List<ClientOrder> clientOrder, bool existMoreOrders)
        {
            this.ClientOrder = clientOrder;
            this.ExistMoreOrders = existMoreOrders;
        }
    }
}