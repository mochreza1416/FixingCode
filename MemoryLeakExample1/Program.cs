using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakExample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var myList = new List<Product>(); // Create a new list in each iteration
                // populate list with 1000 integers
                for (int i = 0; i < 1000; i++)
                {
                    myList.Add(new Product(Guid.NewGuid().ToString(), i));
                }
                // do something with the list object
                Console.WriteLine(myList.Count);
                // Clear the list to release memory
                myList.Clear();
            }
        }
    }
    class Product
    {
        public Product(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
        public string SKU { get; set; }
        public decimal Price { get; set; }
    }
}
