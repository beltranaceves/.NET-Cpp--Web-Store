using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService
{
    public class ShoppingCartService : IShoppingCartService
    {
        [Inject]
        public IProductDao ProductDao { private get; set; }

        public ShoppingCart AddToCart(long productId, int quantity, ShoppingCart shoppingCart)
        {
            for (int i = 0; i < shoppingCart.shoppingCartLines.Count; i++)
            {
                if (shoppingCart.shoppingCartLines.ElementAt(i).productId == productId)
                {
                    shoppingCart.shoppingCartLines.ElementAt(i).quantity++;

                    shoppingCart.shoppingCartLines.ElementAt(i).totalPrice = shoppingCart.shoppingCartLines.ElementAt(i).price * shoppingCart.shoppingCartLines.ElementAt(i).quantity;


                    return shoppingCart;
                }
            }
        
            ShoppingCartLine cartLine = new ShoppingCartLine();

            Product p = ProductDao.Find(productId);

            if (p.stock - quantity < 0)
                throw new NotEnoughStockException(p.productName, quantity);

            cartLine.forGift = false; //Por defecto se pone a false, el usuario podra despues decidir si lo quiere para regalo o no
            cartLine.price = p.price;
            cartLine.quantity = quantity;
            cartLine.productName = p.productName;
            cartLine.totalPrice = cartLine.price * cartLine.quantity;
            cartLine.productId = productId;

            shoppingCart.shoppingCartLines.Add(cartLine);
                

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

            Product p = ProductDao.Find(shoppingCart.shoppingCartLines[aux].productId);

            if (p.stock - units < 0)
                throw new NotEnoughStockException(p.productName, units);

            shoppingCart.shoppingCartLines[aux].quantity = units;

            shoppingCart.shoppingCartLines[aux].totalPrice = shoppingCart.shoppingCartLines[aux].quantity * p.price;

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
