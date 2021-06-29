using ShoppingCartTestLeanOn.Classes.Products;

namespace ShoppingCartTestLeanOn.Factories
{
    public abstract class ProductFactory
    {
        public abstract Product CreateProduct(string name, decimal price, bool imported, int quantity);
    }
}