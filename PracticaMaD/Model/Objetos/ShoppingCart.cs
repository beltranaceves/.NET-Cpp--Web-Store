using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Objetos
{
    public class ShoppingCart
    {

        public List<ShoppingCartLine> shoppingCartLines { get; set; }

        public ShoppingCart()
        {
            shoppingCartLines = new List<ShoppingCartLine>();
        }


    }
}
