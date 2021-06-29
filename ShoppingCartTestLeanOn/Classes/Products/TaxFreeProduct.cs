using ShoppingCartTestLeanOn.Configurations;
using ShoppingCartTestLeanOn.Factories;
using ShoppingCartTestLeanOn.Factories.Products;

namespace ShoppingCartTestLeanOn.Classes.Products
{
    public class TaxFreeProduct : Product
    {
        public TaxFreeProduct()
            : base()
        {
        }

        public TaxFreeProduct(string name, decimal price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {
        }

        public override ProductFactory GetFactory() => new TaxFreeProductFactory();

        public override decimal GetTaxValue(string country)
        {
            return TaxesManager.FreeTaxesTax;
        }
    }
}