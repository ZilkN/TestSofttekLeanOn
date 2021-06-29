using ShoppingCartTestLeanOn.Configurations;
using ShoppingCartTestLeanOn.Utilities;

namespace ShoppingCartTestLeanOn.Taxes
{
    /*Class to handle the taxes calculation, based on the local tax*/

    public class TaxCalculator : ITaxCalculator
    {
        public decimal CalculateTaxForProduct(decimal price, decimal localTax, bool isImported)
        {
            var tax = 0m;

            if (isImported)
                localTax += TaxesManager.ImportedProductTax;

            tax = price * localTax;

            /*Rounds to nearest 0.5*/
            tax = DecimalManagerUtilities.RoundOff(tax);

            /*For testing propurses we are adding 1 to the price to test the different strategy*/

            return tax;
        }
    }
}