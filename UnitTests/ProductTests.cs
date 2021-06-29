using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartTestLeanOn.Billing;
using ShoppingCartTestLeanOn.Cart;
using ShoppingCartTestLeanOn.Classes.Products;
using UnitTests.MockData;
using Xunit;

namespace UnitTests
{
    public class ProductTests
    {
        private readonly CartFiller _cartFiller;
        private CheckOut _checkOut;
        private List<Product> _productList;
        private ShoppingCart _shoppingCart;

        public ProductTests()
        {
            _cartFiller = new CartFiller();
            _productList = new List<Product>();
            _shoppingCart = new ShoppingCart();
        }


        [Theory]
        [ClassData(typeof(ProductsMockData))]

        public void CheckOutTest(List<ProductMockModel> productList, TotalsMockModel expectedTotal )
        {
            foreach (var product in productList)
            {
                var productData = _cartFiller.RetrieveItemFromShelf(product.Name, product.Price, product.IsImported, product.Quantity);
                _productList.Add(productData);
                
            }

            _shoppingCart = new ShoppingCart(_productList);

            _checkOut = new CheckOut();

            _checkOut.InvoiceItemsInCart(_shoppingCart);
             var invoice = _checkOut.GetReceipt();

             var objTotals = new TotalsMockModel
             {
                 TotalAmount = $"{invoice.TotalAmount:0.00}",
                 TotalTaxes = $"{invoice.TotalSalesTax:0.00}"
             };
            
             Assert.Equal(expectedTotal.TotalAmount, objTotals.TotalAmount);
             Assert.Equal(expectedTotal.TotalTaxes, objTotals.TotalTaxes);

            //Assert.Equal(expectedTotal, objTotals);

        }
    }
}
