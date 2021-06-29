using ShoppingCartTestLeanOn.Configurations;
using ShoppingCartTestLeanOn.Factories;
using ShoppingCartTestLeanOn.Factories.Products;

namespace ShoppingCartTestLeanOn.Classes.Products
{
    public class MiscProduct : Product
    {
        public MiscProduct()
            : base()
        {
        }

        public MiscProduct(string name, decimal price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {
        }

        public override ProductFactory GetFactory() => new MiscProductFactory();

        public override decimal GetTaxValue(string country)
        {
            return TaxesManager.MiscTax;
        }
    }
}