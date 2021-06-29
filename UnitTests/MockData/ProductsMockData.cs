using System.Collections;
using System.Collections.Generic;

namespace UnitTests.MockData
{
    public class ProductMockModel
    {
        public bool IsImported { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class TotalsMockModel
    {
        public string TotalTaxes { get; set; }
        public string TotalAmount { get; set; }
    }

    /*This are the test that were on the PDF*/
    internal class ProductsMockData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
                {new List<ProductMockModel>
                {
                    new() {Name = "book", Quantity = 1, Price = 12.49m, IsImported = false},
                    new() {Name = "book", Quantity = 1, Price = 12.49m, IsImported = false},
                    new() {Name = "chocolate bar", Quantity = 1, Price = 0.85m, IsImported = false},
                    new() {Name = "music cd", Quantity = 1, Price = 14.99m, IsImported = false}

                }, new TotalsMockModel() {TotalAmount = "42.32", TotalTaxes = "1.50"}};

            yield return new object[]
            {new List<ProductMockModel>
            {
                new() {Name = "box of chocolates", Quantity = 1, Price = 10.00m, IsImported = true},
                new() {Name = "bottle of perfume", Quantity = 1, Price = 47.50m, IsImported = true}

            }, new TotalsMockModel() {TotalAmount = "65.15", TotalTaxes = "7.65"}};

            yield return new object[]
            {new List<ProductMockModel>
            {
                new() {Name = "box of chocolates", Quantity = 1, Price = 11.25m, IsImported = true},
                new() {Name = "box of chocolates", Quantity = 1, Price = 11.25m, IsImported = true},
                new() {Name = "bottle of perfume", Quantity = 1, Price = 27.99m, IsImported = true},
                new() {Name = "bottle of perfume", Quantity = 1, Price = 18.99m, IsImported = false},
                new() {Name = "packet of headache pills", Quantity = 1, Price = 9.75m, IsImported = false},


            }, new TotalsMockModel() {TotalAmount = "86.53", TotalTaxes = "7.30"}};




        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}