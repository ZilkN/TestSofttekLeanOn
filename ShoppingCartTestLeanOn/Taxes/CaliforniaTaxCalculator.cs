using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartTestLeanOn.Configurations;
using ShoppingCartTestLeanOn.Utilities;

namespace ShoppingCartTestLeanOn.Taxes
{
    /*For testing porpuses in this strategy we'll substract the price when the product is imported*/
    class CaliforniaTaxCalculator : ITaxCalculator

    {
        public decimal CalculateTaxForProduct(decimal price, decimal localTax, bool isImported)
        {
            var tax = price * localTax;

            if (isImported)
                tax -= (price * TaxesManager.ImportedProductTax);

            /*Rounds to nearest 0.5*/
            tax = DecimalManagerUtilities.RoundOff(tax);


            return tax;
        }
    }
}
