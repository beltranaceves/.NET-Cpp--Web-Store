using Es.Udc.DotNet.PracticaMad.Model.Objetos;


namespace Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService
{
    public interface IShoppingCartService
    {
        ShoppingCart AddToCart(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart);

        ShoppingCart RemoveFromCart(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart);

        ShoppingCart UpdateNumberOfUnits(ShoppingCartLine shoppingCart, ShoppingCart shoppingCartLine, int quantity);

        ShoppingCart UpdateForGiftStatus(ShoppingCartLine shoppingCart, ShoppingCart shoppingCartLine, bool forG);

        ShoppingCartLine GetCartLine(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart);
    }
}
