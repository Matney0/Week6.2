using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6._2
{
//Primary class
        public class Product
        {
//Public properties 
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
//class for the shopping cart
        public class ShoppingCart
        {
//dont want inerfaces and lists to get mixed up. also more private
            private List<Product> products;

//visable shopping cart
            public ShoppingCart()
            {
//adds products to a list
                products = new List<Product>();
            }
//Adding products to the Product list
            public void AddProduct(Product product)
            {
                products.Add(product);
            }
//Removing products from the Product list
            public void RemoveProduct(string productId)
            {
                products.RemoveAll(p => p.ProductID == productId);
            }
//Method to calculate the price 
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
//Shopping cart list for the shopping cart method
                ShoppingCart cart = new ShoppingCart();
//Loops while true 
                while (true)
                {
//Menu options for the user to chose from
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Remove Product");
                    Console.WriteLine("3. View Total Price");
                    Console.WriteLine("4. Exit");
                    string choice = Console.ReadLine();
//First choice
                    if (choice == "1")
                    {
//Asks and stores product
                        Console.WriteLine("Enter Product ID:");
                        string productId = Console.ReadLine();
                        Console.WriteLine("Enter Product Name:");
                        string productName = Console.ReadLine();
                        Console.WriteLine("Enter Product Price:");
//Aks and converts value to computer language 
                        double price = Convert.ToDouble(Console.ReadLine());

//For the product list and all its information/values
                        Product product = new Product(productId, productName, price);
//Uses AddProdcut method
                        cart.AddProduct(product);
                        Console.WriteLine("Product added to cart.");
                    }
//Asks for the product name and removes it if found
                    else if (choice == "2")
                    {
                        Console.WriteLine("Enter Product ID to remove:");
                        string productId = Console.ReadLine();
                        cart.RemoveProduct(productId);
                        Console.WriteLine("Product removed from cart.");
                    }
//Shows the price of all products
                    else if (choice == "3")
                    {
                        Console.WriteLine($"Total Price: ${cart.CalculateTotalPrice():F2}");
                    }
//Exit
                    else if (choice == "4")
                    {
                        break;
                    }
//Invalid option entered
                    else
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                    }
                }
            }
        }
    }
