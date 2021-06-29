namespace ShoppingCartTestLeanOn.Taxes
{
    // <summary>
    // Interface in charge of declaring the taxing stuff
    // </summary>
    public interface ITaxCalculator
    {
        decimal CalculateTaxForProduct(decimal price, decimal tax, bool isImported);
    }
}