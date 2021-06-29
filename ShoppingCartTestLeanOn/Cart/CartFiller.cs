using ShoppingCartTestLeanOn.Billing;
using ShoppingCartTestLeanOn.Classes.Products;
using ShoppingCartTestLeanOn.Shelf;
using System;

namespace ShoppingCartTestLeanOn.Cart
{
    public class CartFiller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly StoreShelf _storeShelf;
        private readonly CheckOut _checkOut;
        private string _name;

        public CartFiller()
        {
            _shoppingCart = new ShoppingCart();
            _storeShelf = new StoreShelf();
            _checkOut = new CheckOut();
        }

        public void GetSalesOrder()
        {
            /*Will start the inputs for the data*/
            do
            {
                _name = GetProductName();
                var price = GetProductPrice();
                var quantity = GetQuantity();
                var isImported = IsProductImported();

                RetrieveItemFromShelf(_name, price, isImported, quantity);
            } while (AddAnotherProduct());
        }

        public void CheckOut()
        {
            _checkOut.InvoiceItemsInCart(_shoppingCart);

            var receipt = _checkOut.GetReceipt();
            _checkOut.PrintReceipt(receipt);
        }

        private string GetProductName()
        {
            Console.WriteLine("Enter the product name");
            var productName = Console.ReadLine();
            var productExist = _storeShelf.CheckIfItemExist(productName);
            while (!productExist)
            {
                Console.WriteLine("This item doesn't exist please enter a valid item");

                productName = Console.ReadLine();

                productExist = _storeShelf.CheckIfItemExist(productName);
            }

            return productName;
        }

        private decimal GetProductPrice()
        {
            Console.WriteLine($"Please input the product price for {_name}");
            var input = Console.ReadLine();
            var isValidNumber = (decimal.TryParse(input, out var value));

            isValidNumber = value >= 0;
            while (!isValidNumber)
            {
                Console.WriteLine("Invalid price, please enter a number");
                input = Console.ReadLine();
                isValidNumber = decimal.TryParse(input, out value);
            }

            return value;
        }

        private bool IsProductImported()
        {
            Console.WriteLine("Is the product imported from another country? (Y/N)");
            var input = Console.ReadLine()?.ToLower();
            while (!validateBooleanInputsFromText(input))
            {
                validateBooleanInputsFromText(input);
            }

            return input == "y";
        }

        private int GetQuantity()
        {
            Console.WriteLine("How many?");
            var input = Console.ReadLine();
            var isValidNumber = int.TryParse(input, out var quantity);

            isValidNumber = quantity >= 0;
            while (!isValidNumber)
            {
                Console.WriteLine("Invalid input. Enter a integer number");
                input = Console.ReadLine();
                isValidNumber = int.TryParse(input, out quantity);
            }

            return quantity;
        }

        /*Method to handle if the user wants to add another product or not based on their input*/

        private bool AddAnotherProduct()
        {
            Console.WriteLine("------ Do you want to add another product? (Y/N)");
            var input = Console.ReadLine()?.ToLower();

            while (!validateBooleanInputsFromText(input))
            {
                validateBooleanInputsFromText(input);
            }

            return input == "y";
        }

        /*Will validate the Y OR N input and return to the cicle if is another invalid input*/

        private bool validateBooleanInputsFromText(string input)
        {
            /*Will get the value to add if is imported or not*/
            switch (input)
            {
                case "y":
                    return true;

                case "n":
                    return true;

                default:
                    Console.WriteLine("Invalid input. Enter (Y/N)");
                    input = Console.ReadLine()?.ToLower();

                    break;
            }

            return true;
        }

        public Product RetrieveItemFromShelf(string name, decimal price, bool isImported, int quantity)
        {
            var product = _storeShelf.GetItemFromShelf(name, price, isImported, quantity);
            _shoppingCart.AddItemToCart(product);

            return product;
        }
    }
}