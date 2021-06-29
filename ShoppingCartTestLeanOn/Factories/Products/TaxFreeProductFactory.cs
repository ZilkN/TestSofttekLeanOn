using ShoppingCartTestLeanOn.Classes.Products;

namespace ShoppingCartTestLeanOn.Factories.Products
{
    public class TaxFreeProductFactory : ProductFactory
    {
        public override Product CreateProduct(string name, decimal price, bool imported, int quantity)
        {
            return new TaxFreeProduct(name, price, imported, quantity);
        }
    }
}