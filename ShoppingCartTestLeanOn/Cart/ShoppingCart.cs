using ShoppingCartTestLeanOn.Classes.Products;
using System.Collections.Generic;

namespace ShoppingCartTestLeanOn.Cart
{
    /*Base class that will handle the movements of the shopping cart*/

    public class ShoppingCart
    {
        /*List that will contain the items added to the cart!*/
        private List<Product> _productList { get; set; }


        public ShoppingCart(List<Product> productList)
        {
            _productList = productList;
        }
        public ShoppingCart()
        {
            _productList = new List<Product>();
        }

        public List<Product> GetItemsFromCart()
        {
            return _productList;
        }

        public void AddItemToCart(Product product)
        {
            _productList.Add(product);
        }
    }
}