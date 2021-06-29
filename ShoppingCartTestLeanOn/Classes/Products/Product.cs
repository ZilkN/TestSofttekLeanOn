using ShoppingCartTestLeanOn.Factories;

namespace ShoppingCartTestLeanOn.Classes.Products
{
    
    public abstract class Product
    {
        #region Properties
        private decimal _price;

        public string Name { get; }

        public bool IsImported { get; set; }

        public decimal TaxedCost { get; set; }
        public int Quantity { get; set; }

        public decimal Price
        {
            get => _price * Quantity;
            set => _price = value;
        }

        #endregion Properties

        #region Constructors

        protected Product()
        {
            Name = string.Empty;
            Price = 0.0m;
            IsImported = false;
            Quantity = 0;
            TaxedCost = 0.0m;
        }

        protected Product(string name, decimal price, bool imported, int quantity)
        {
            Name = name;
            Price = price;
            IsImported = imported;
            Quantity = quantity;
        }

        #endregion Constructors

        #region Public Methods

        /*Method to convert the product into a string to show into the bill*/

        public string ProductToStringLine()
        {
            return $"{Quantity} {ImportedString(IsImported)} {Name} {TaxedCost}";
        }

        /*I'll get the factory of the product to handle the taxes and stuff*/

        public abstract ProductFactory GetFactory();

        public abstract decimal GetTaxValue(string country);

        #endregion Public Methods

        #region Private Methods

        /*If the product is imported i'll add the line imported before the product name*/

        private string ImportedString(bool isImported)
        {
            return !isImported ? string.Empty : "Imported";
        }

        #endregion Private Methods
    }
}