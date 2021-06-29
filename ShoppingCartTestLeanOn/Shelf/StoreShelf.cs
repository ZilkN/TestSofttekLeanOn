using ShoppingCartTestLeanOn.Classes.Products;
using System.Collections.Generic;

namespace ShoppingCartTestLeanOn.Shelf
{
    public class StoreShelf
    {
        private Dictionary<string, Product> shelfItems;

        public StoreShelf()
        {
            shelfItems = new Dictionary<string, Product>();
            AddProductItemsToShelf("book", new TaxFreeProduct());
            AddProductItemsToShelf("music cd", new MiscProduct());
            AddProductItemsToShelf("chocolate bar", new TaxFreeProduct());
            AddProductItemsToShelf("box of chocolates", new TaxFreeProduct());
            AddProductItemsToShelf("bottle of perfume", new MiscProduct());
            AddProductItemsToShelf("packet of headache pills", new TaxFreeProduct());
        }

        private void AddProductItemsToShelf(string productItem, Product productCategory)
        {
            shelfItems.Add(productItem, productCategory);
        }

        public bool CheckIfItemExist(string name)
        {
            return shelfItems.ContainsKey(name);
        }

        public Product GetItemFromShelf(string name, decimal price, bool imported, int quantity)
        {
            var productExist = shelfItems.TryGetValue(name, out var product);

            if (!productExist)
                return null;

            var productItem = product
                .GetFactory()
                .CreateProduct(name, price, imported, quantity);
            return productItem;
        }
    }
}