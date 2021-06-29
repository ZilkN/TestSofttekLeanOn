using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartTestLeanOn.Billing;
using ShoppingCartTestLeanOn.Taxes;
using ShoppingCartTestLeanOn.Utilities;
using Xunit;

namespace UnitTests
{
    public class TaxesTests
    {
        private BillingHelper _billingHelper;
        private readonly TaxCalculatorFactory _factory = new();

        public TaxesTests()
        {
            var taxCalculatorFactory = _factory.GetTaxCalculator("Local");
            _billingHelper = new BillingHelper(taxCalculatorFactory);
        }

        [Theory]
        [InlineData(27.99, true, 0.10, 4.20)]
        [InlineData(18.99, false, 0.10, 1.90)]
        public void CalculateTax(decimal price, bool isImported, decimal taxRate, decimal expected)
        {


            var taxes = _billingHelper.CalculateTax(price, taxRate, isImported);

            Assert.Equal(expected, taxes);
        }

        [Theory]
        [InlineData(27.99, 4.20, 32.19 )]

        public void TotalProductCost(decimal price, decimal tax, decimal expected)
        {
            var sum = _billingHelper.CalculateTotalProductCost(price, tax);

            Assert.Equal(expected, sum);
        }
    }
}
