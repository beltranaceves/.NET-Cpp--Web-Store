using Es.Udc.DotNet.PracticaMad.Model.Objetos;


namespace Es.Udc.DotNet.PracticaMad.Model.Services.ShoppingCartService
{
    public interface IShoppingCartService
    {
        ShoppingCart AddToCart(long productId, int quantity, ShoppingCart shoppingCart);

        ShoppingCart RemoveFromCart(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart);

        ShoppingCart UpdateNumberOfUnits(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart, int quantity);

        ShoppingCart UpdateForGiftStatus(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart, bool forG);

        ShoppingCartLine GetCartLine(ShoppingCartLine shoppingCartLine, ShoppingCart shoppingCart);
    }
}
