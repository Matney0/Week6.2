using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6._2
{
        public class Product
        {
            public string ProductID { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }

            public Product(string productId, string productName, double price)
            {
                ProductID = productId;
                ProductName = productName;
                Price = price;
            }
        }

        public class ShoppingCart
        {
            private List<Product> products;

            public ShoppingCart()
            {
                products = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                products.Add(product);
            }

            public void RemoveProduct(string productId)
            {
                products.RemoveAll(p => p.ProductID == productId);
            }

            public double CalculateTotalPrice()
            {
                double total = 0;
                foreach (var product in products)
                {
                    total += product.Price;
                }
                return total;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                ShoppingCart cart = new ShoppingCart();

                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Remove Product");
                    Console.WriteLine("3. View Total Price");
                    Console.WriteLine("4. Exit");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.WriteLine("Enter Product ID:");
                        string productId = Console.ReadLine();
                        Console.WriteLine("Enter Product Name:");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Enter Product Price:");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Product product = new Product(productId, productName, price);
                        cart.AddProduct(product);
                        Console.WriteLine("Product added to cart.");
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("Enter Product ID to remove:");
                        string productId = Console.ReadLine();
                        cart.RemoveProduct(productId);
                        Console.WriteLine("Product removed from cart.");
                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine($"Total Price: ${cart.CalculateTotalPrice():F2}");
                    }
                    else if (choice == "4")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
            }
        }
    }
