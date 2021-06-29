using ShoppingCartTestLeanOn.Cart;

namespace ShoppingCartTestLeanOn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CartFiller cartFiller = new CartFiller();
            cartFiller.GetSalesOrder();
            cartFiller.CheckOut();
        }
    }
}