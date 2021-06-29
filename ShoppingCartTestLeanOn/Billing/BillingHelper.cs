using ShoppingCartTestLeanOn.Classes.Products;
using ShoppingCartTestLeanOn.Taxes;
using ShoppingCartTestLeanOn.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartTestLeanOn.Billing
{
    public class BillingHelper
    {
        private readonly ITaxCalculator _taxCalculator;

        public BillingHelper(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public decimal CalculateTax(decimal price, decimal tax, bool isImported)
        {
            return _taxCalculator.CalculateTaxForProduct(price, tax, isImported);
        }

        public decimal CalculateTotalProductCost(decimal price, decimal tax)
        {
            return DecimalManagerUtilities.Truncate(price + tax);
        }

        /*Calculates the total amounts of the products in the list*/
        public decimal CalculateTotalAmount(List<Product> prodList)
        {
            var totalAmount = 0.0m;

            totalAmount = prodList.Sum(x => x.TaxedCost);

            return DecimalManagerUtilities.Truncate(totalAmount);
        }

        /*Calculates only the total amount of taxes */
        public decimal CalculateTotalTax(List<Product> prodList)
        {

            var totalTax = 0.0m;

            totalTax = prodList.Sum(x => x.TaxedCost - x.Price);
            

            return DecimalManagerUtilities.Truncate(totalTax);
        }

        public Invoice CreateNewReceipt(List<Product> productList, decimal totalTax, decimal totalAmount)
        {
            return new(productList, totalTax, totalAmount);
        }

        public void GenerateReceipt(Invoice invoice)
        {
            string receipt = invoice.InvoiceToString();
            Console.WriteLine(receipt);
        }

        /*This will group by name the list and then calculate the taxes and the quantity*/

        public BillingHelper GetBiller(string strategy)
        {
            TaxCalculatorFactory factory = new TaxCalculatorFactory();
            ITaxCalculator taxCal = factory.GetTaxCalculator(strategy);
            return new BillingHelper(taxCal);
        }
    }
}