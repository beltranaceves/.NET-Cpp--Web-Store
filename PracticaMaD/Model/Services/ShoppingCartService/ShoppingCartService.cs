using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService
{
    public class ShoppingCartService : IShoppingCartService
    {

       public ShoppingCart AddToCart(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart)
        {
             if (shoppingCart.shoppingCartLines.Contains(shoppingCartLine))
                    throw new AlreadyAddedException(shoppingCartLine.productId);
            
            shoppingCart.shoppingCartLines.Add(shoppingCartLine);

            return shoppingCart;
        }

        public ShoppingCart RemoveFromCart(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart)
        {

            if (!(shoppingCart.shoppingCartLines.Contains(shoppingCartLine)))
                    throw new InstanceNotFoundException(shoppingCartLine,typeof(ShoppingCart).FullName);

            shoppingCart.shoppingCartLines.Remove(shoppingCartLine);

            return shoppingCart;

        }

        public ShoppingCart UpdateNumberOfUnits(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart, int units){

            if (!(shoppingCart.shoppingCartLines.Contains(shoppingCartLine)))
                    throw new InstanceNotFoundException(shoppingCartLine, typeof(ShoppingCart).FullName);

            int aux =  shoppingCart.shoppingCartLines.IndexOf(shoppingCartLine);
            shoppingCart.shoppingCartLines[aux].quantity = units;

            return shoppingCart;

        }

        public ShoppingCart UpdateForGiftStatus(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart,bool forG){

            if (!(shoppingCart.shoppingCartLines.Contains(shoppingCartLine)))
                    throw new InstanceNotFoundException(shoppingCartLine, typeof(ShoppingCart).FullName);

            int aux =  shoppingCart.shoppingCartLines.IndexOf(shoppingCartLine);
            shoppingCart.shoppingCartLines[aux].forGift = forG;

            return shoppingCart;

        }

        public ShoppingCartLine GetCartLine(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart)
        {

            if (!(shoppingCart.shoppingCartLines.Contains(shoppingCartLine)))
                    throw new InstanceNotFoundException(shoppingCartLine, typeof(ShoppingCart).FullName);

            ShoppingCartLine sc = shoppingCart.shoppingCartLines[shoppingCart.shoppingCartLines.IndexOf(shoppingCartLine)];

            return sc;     
        }


    }

}
