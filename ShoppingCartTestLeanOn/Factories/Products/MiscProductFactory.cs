using ShoppingCartTestLeanOn.Classes.Products;

namespace ShoppingCartTestLeanOn.Factories.Products
{
    public class MiscProductFactory : ProductFactory
    {
        public override Product CreateProduct(string name, decimal price, bool imported, int quantity)
        {
            return new MiscProduct(name, price, imported, quantity);
        }
    }
}