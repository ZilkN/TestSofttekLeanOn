using ShoppingCartTestLeanOn.Classes.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartTestLeanOn.Billing
{
    public class Invoice
    {
        private List<Product> ProductList { get; set; }
        public  decimal TotalSalesTax { get; set; }
        public decimal TotalAmount { get; set; }

        public Invoice(List<Product> productList, decimal tax, decimal amount)
        {
            ProductList = productList;
            TotalSalesTax = tax;
            TotalAmount = amount;
        }

        /*Takes the produclist, groups it and makes a string of the itemsbased on the format that was requested*/

        public string InvoiceToString()
        {
            string receipt = "";
            Console.WriteLine("---- This is your invoice ----");

            var groupedList = ProductList.GroupBy(m => m.Name).Select(g => new
            {
                Name = g.Key,
                Quantity = g.Sum(x => x.Quantity),
                _price = g.Sum(x => x.Price),
                Taxes = g.Sum(x => x.TaxedCost)
            }).ToList();

            foreach (var p in groupedList)
            {
                if (p.Quantity > 1)
                    receipt += $"{p.Name}: {p._price} ({p.Quantity} @ {p._price / p.Quantity})\n";
                else
                    receipt += ($"{p.Name}: {p._price}" + "\n");
            }

            receipt += "Total sales tax = " + TotalSalesTax + "\n";
            receipt += "Total amount = " + TotalAmount + "\n";
            
            return receipt;
        }
    }
}