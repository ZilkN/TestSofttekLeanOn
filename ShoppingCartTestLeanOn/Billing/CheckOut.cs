using ShoppingCartTestLeanOn.Cart;
using ShoppingCartTestLeanOn.Classes.Products;
using ShoppingCartTestLeanOn.Taxes;
using System;
using System.Collections.Generic;

namespace ShoppingCartTestLeanOn.Billing
{
    public class CheckOut
    {
        private BillingHelper _billingHelper;
        private Invoice _invoice;
        private List<Product> _productList;

        public CheckOut()
        {
            
        }

        public CheckOut(List<Product> productList)
        {
            _productList = productList;
        }

        public void InvoiceItemsInCart(ShoppingCart cart)
        {
            _billingHelper = GetBiller("Local");
            _productList = cart.GetItemsFromCart();
            foreach (var product in _productList)
            {
                decimal productTax =
                    _billingHelper.CalculateTax(product.Price, product.GetTaxValue("Local"), product.IsImported);

                decimal taxedCost = _billingHelper.CalculateTotalProductCost(product.Price, productTax);

                product.TaxedCost = taxedCost;
            }
        }

        public Invoice GetReceipt()
        {
            var totalTax = _billingHelper.CalculateTotalTax(_productList);
            var totalAmount = _billingHelper.CalculateTotalAmount(_productList);
            _invoice = _billingHelper.CreateNewReceipt(_productList, totalTax, totalAmount);
            return _invoice;
        }
        

        public void PrintReceipt(Invoice invoice)
        {
            _billingHelper.GenerateReceipt(invoice);
        }

        private BillingHelper GetBiller(String strategy)
        {
            TaxCalculatorFactory factory = new TaxCalculatorFactory();
            ITaxCalculator taxCal = factory.GetTaxCalculator(strategy);
            return new BillingHelper(taxCal);
        }
    }
}