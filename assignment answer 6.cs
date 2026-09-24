using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Assignment_Session09
{
    // =========================================================================
    // Data Models used for LINQ Queries
    // =========================================================================
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public override string ToString()
        {
            return $"ID: {ProductID}, Name: {ProductName}, Category: {Category}, Price: {UnitPrice:C}, Stock: {UnitsInStock}";
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public Order[] Orders { get; set; }

        public override string ToString()
        {
            return $"ID: {CustomerID}, Name: {CustomerName}, City: {City}, Orders Count: {Orders?.Length ?? 0}";
        }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public override string ToString()
        {
            return $"OrderID: {OrderID}, Date: {OrderDate.ToShortDateString()}, Total: {Total:C}";
        }
    }

    // List Generators
    public static class ListGenerators
    {
        public static List<Product> ProductList = new List<Product>()
        {
            new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00m, UnitsInStock = 39 },
            new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00m, UnitsInStock = 17 },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00m, UnitsInStock = 13 },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00m, UnitsInStock = 53 },
            new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.35m, UnitsInStock = 0 },
            new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00m, UnitsInStock = 120 },
            new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.00m, UnitsInStock = 15 },
            new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.00m, UnitsInStock = 6 },
            new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.00m, UnitsInStock = 29 },
            new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00m, UnitsInStock = 31 }
        };

        public static List<Customer> CustomerList = new List<Customer>()
        {
            new Customer
            {
                CustomerID = "ALFKI",
                CustomerName = "Alfreds Futterkiste",
                City = "Berlin",
                Orders = new Order[]
                {
                    new Order { OrderID = 10643, OrderDate = new DateTime(1997, 8, 25), Total = 814.50m },
                    new Order { OrderID = 10692, OrderDate = new DateTime(1997, 10, 3), Total = 878.00m },
                    new Order { OrderID = 10702, OrderDate = new DateTime(1997, 10, 13), Total = 330.00m }
                }
            },
            new Customer
            {
                CustomerID = "ANATR",
                CustomerName = "Ana Trujillo Emparedados y helados",
                City = "Mexico D.F.",
                Orders = new Order[]
                {
                    new Order { OrderID = 10308, OrderDate = new DateTime(1996, 9, 18), Total = 88.80m },
                    new Order { OrderID = 10625, OrderDate = new DateTime(1997, 8, 8), Total = 479.75m }
                }
            },
            new Customer
            {
                CustomerID = "ANTON",
                CustomerName = "Antonio Moreno Taquería",
                City = "Mexico D.F.",
                Orders = new Order[]
                {
                    new Order { OrderID = 10365, OrderDate = new DateTime(1996, 11, 27), Total = 403.20m },
                    new Order { OrderID = 10507, OrderDate = new DateTime(1997, 4, 15), Total = 749.00m }
                }
            },
            new Customer
            {
                CustomerID = "WASSH",
                CustomerName = "Washington Store",
                City = "Washington",
                Orders = new Order[] { } // Customer with 0 orders
            }
        };
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var products = ListGenerators.ProductList;
            var customers = ListGenerators.CustomerList;

            // =========================================================================
            // PART 1: LINQ - Restriction Operators (Where)
            // =========================================================================
            Console.WriteLine("=========================================================================");
            Console.WriteLine("                   PART 1: RESTRICTION OPERATORS                         ");
            Console.WriteLine("=========================================================================");

            // --- Question 1: Find all products that are out of stock ---
            Console.WriteLine("\n--- Q1: Out of stock products ---");
            var q1 = products.Where(p => p.UnitsInStock == 0);
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 2: Products in stock and cost more than 30.00 ---
            Console.WriteLine("--- Q2: In stock AND Price > 30.00 ---");
            var q2 = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 30.00m);
            foreach (var item in q2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 3: Digits whose name is shorter than their value ---
            Console.WriteLine("--- Q3: Digits with name shorter than value ---");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q3 = digits.Where((name, index) => name.Length < index);
            foreach (var item in q3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n=========================================================================\n");

            // =========================================================================
            // PART 2: LINQ - Element Operators
            // =========================================================================
            Console.WriteLine("                   PART 2: ELEMENT OPERATORS                             ");
            Console.WriteLine("=========================================================================");

            // --- Question 1: First product out of stock ---
            Console.WriteLine("\n--- Q1: First out of stock product ---");
            var q2_1 = products.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine(q2_1);

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 2: First product whose Price > 1000 or null ---
            Console.WriteLine("--- Q2: First product Price > 1000 (or null) ---");
            var q2_2 = products.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(q2_2 == null ? "Null (No product found)" : q2_2.ToString());

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 3: Retrieve second number greater than 5 ---
            Console.WriteLine("--- Q3: Second number greater than 5 ---");
            int[] numbersArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q2_3 = numbersArr.Where(n => n > 5).ElementAtOrDefault(1);
            Console.WriteLine("Second number > 5 is: " + q2_3);

            Console.WriteLine("\n=========================================================================\n");

            // =========================================================================
            // PART 3: LINQ - Set Operators
            // =========================================================================
            Console.WriteLine("                   PART 3: SET OPERATORS                                 ");
            Console.WriteLine("=========================================================================");

            // --- Question 1: Unique Category names ---
            Console.WriteLine("\n--- Q1: Unique product categories ---");
            var q3_1 = products.Select(p => p.Category).Distinct();
            foreach (var cat in q3_1)
            {
                Console.WriteLine(cat);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 2: Unique first letters from product and customer names ---
            Console.WriteLine("--- Q2: Unique first letters of Product and Customer names ---");
            var prodFirstLetters = products.Select(p => p.ProductName[0]);
            var custFirstLetters = customers.Select(c => c.CustomerName[0]);
            var q3_2 = prodFirstLetters.Union(custFirstLetters);
            foreach (var letter in q3_2)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 3: Common first letters between products and customers ---
            Console.WriteLine("--- Q3: Common first letters between Products and Customers ---");
            var q3_3 = prodFirstLetters.Intersect(custFirstLetters);
            foreach (var letter in q3_3)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 4: First letters of products NOT in customer names ---
            Console.WriteLine("--- Q4: First letters in Products but NOT in Customers ---");
            var q3_4 = prodFirstLetters.Except(custFirstLetters);
            foreach (var letter in q3_4)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 5: Last 3 characters of all product and customer names ---
            Console.WriteLine("--- Q5: Last 3 characters of Product and Customer names ---");
            var prodLastChars = products.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName);
            var custLastChars = customers.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName);
            var q3_5 = prodLastChars.Concat(custLastChars);
            foreach (var str in q3_5)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("\n=========================================================================\n");

            // =========================================================================
            // PART 4: LINQ - Aggregate Operators
            // =========================================================================
            Console.WriteLine("                   PART 4: AGGREGATE OPERATORS                           ");
            Console.WriteLine("=========================================================================");

            // --- Question 1: Count odd numbers in array ---
            Console.WriteLine("\n--- Q1: Count of odd numbers in array ---");
            int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q4_1 = numbers4.Count(n => n % 2 != 0);
            Console.WriteLine("Odd numbers count: " + q4_1);

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 2: Customers and how many orders each has ---
            Console.WriteLine("--- Q2: Customer list with order counts ---");
            var q4_2 = customers.Select(c => new
            {
                CustomerID = c.CustomerID,
                CustomerName = c.CustomerName,
                OrderCount = c.Orders.Length
            });
            foreach (var item in q4_2)
            {
                Console.WriteLine($"Customer: {item.CustomerName}, Orders: {item.OrderCount}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 3: Categories and how many products each has ---
            Console.WriteLine("--- Q3: Categories and product counts ---");
            var q4_3 = products.GroupBy(p => p.Category)
                               .Select(g => new
                               {
                                   Category = g.Key,
                                   ProductCount = g.Count()
                               });
            foreach (var item in q4_3)
            {
                Console.WriteLine($"Category: {item.Category}, Count: {item.ProductCount}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 4: Total sum of numbers in array ---
            Console.WriteLine("--- Q4: Total sum of array numbers ---");
            var q4_4 = numbers4.Sum();
            Console.WriteLine("Sum: " + q4_4);

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 5: Total units in stock per product category ---
            Console.WriteLine("--- Q5: Total units in stock per category ---");
            var q4_5 = products.GroupBy(p => p.Category)
                               .Select(g => new
                               {
                                   Category = g.Key,
                                   TotalStock = g.Sum(p => p.UnitsInStock)
                               });
            foreach (var item in q4_5)
            {
                Console.WriteLine($"Category: {item.Category}, Total Stock: {item.TotalStock}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 6: Cheapest price in each category ---
            Console.WriteLine("--- Q6: Cheapest price per category ---");
            var q4_6 = products.GroupBy(p => p.Category)
                               .Select(g => new
                               {
                                   Category = g.Key,
                                   CheapestPrice = g.Min(p => p.UnitPrice)
                               });
            foreach (var item in q4_6)
            {
                Console.WriteLine($"Category: {item.Category}, Minimum Price: {item.CheapestPrice:C}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 7: Products with cheapest price in each category ---
            Console.WriteLine("--- Q7: Products with cheapest price per category ---");
            var q4_7 = products.GroupBy(p => p.Category)
                               .SelectMany(g => g.Where(p => p.UnitPrice == g.Min(p2 => p2.UnitPrice)));
            foreach (var item in q4_7)
            {
                Console.WriteLine($"Category: {item.Category}, Product: {item.ProductName}, Price: {item.UnitPrice:C}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 8: Most expensive price in each category ---
            Console.WriteLine("--- Q8: Most expensive price per category ---");
            var q4_8 = products.GroupBy(p => p.Category)
                               .Select(g => new
                               {
                                   Category = g.Key,
                                   MaxPrice = g.Max(p => p.UnitPrice)
                               });
            foreach (var item in q4_8)
            {
                Console.WriteLine($"Category: {item.Category}, Max Price: {item.MaxPrice:C}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 9: Products with most expensive price in each category ---
            Console.WriteLine("--- Q9: Products with most expensive price per category ---");
            var q4_9 = products.GroupBy(p => p.Category)
                               .SelectMany(g => g.Where(p => p.UnitPrice == g.Max(p2 => p2.UnitPrice)));
            foreach (var item in q4_9)
            {
                Console.WriteLine($"Category: {item.Category}, Product: {item.ProductName}, Price: {item.UnitPrice:C}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 10: Average price of products in each category ---
            Console.WriteLine("--- Q10: Average price per category ---");
            var q4_10 = products.GroupBy(p => p.Category)
                                .Select(g => new
                                {
                                    Category = g.Key,
                                    AvgPrice = g.Average(p => p.UnitPrice)
                                });
            foreach (var item in q4_10)
            {
                Console.WriteLine($"Category: {item.Category}, Average Price: {item.AvgPrice:C}");
            }

            Console.WriteLine("\n=========================================================================\n");

            // =========================================================================
            // PART 5: LINQ - Ordering Operators
            // =========================================================================
            Console.WriteLine("                   PART 5: ORDERING OPERATORS                            ");
            Console.WriteLine("=========================================================================");

            // --- Question 1: Sort products by name ---
            Console.WriteLine("\n--- Q1: Sort products by name ---");
            var q5_1 = products.OrderBy(p => p.ProductName);
            foreach (var item in q5_1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 2: Case-insensitive sort of words in array ---
            Console.WriteLine("--- Q2: Case-insensitive sort of words ---");
            string[] wordsArr = { "aPPLE", "AbC", "apple", "this", "case", "there" };
            var q5_2 = wordsArr.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in q5_2)
            {
                Console.WriteLine(w);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 3: Sort products by stock highest to lowest ---
            Console.WriteLine("--- Q3: Sort products by stock descending ---");
            var q5_3 = products.OrderByDescending(p => p.UnitsInStock);
            foreach (var item in q5_3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 4: Sort digits by length then name ---
            Console.WriteLine("--- Q4: Sort digits by length then name ---");
            string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q5_4 = digitsArr.OrderBy(d => d.Length).ThenBy(d => d);
            foreach (var d in q5_4)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 5: Sort words by length then case-insensitive ---
            Console.WriteLine("--- Q5: Sort words by length then case-insensitive ---");
            var q5_5 = wordsArr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in q5_5)
            {
                Console.WriteLine(w);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 6: Sort products by category then price high to low ---
            Console.WriteLine("--- Q6: Sort products by category then price descending ---");
            var q5_6 = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var item in q5_6)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 7: Sort words by length then descending case-insensitive ---
            Console.WriteLine("--- Q7: Sort words by length then descending case-insensitive ---");
            var q5_7 = wordsArr.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in q5_7)
            {
                Console.WriteLine(w);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 8: Create list of digits whose second letter is 'i' reversed ---
            Console.WriteLine("--- Q8: Digits with 'i' as 2nd letter reversed ---");
            var q5_8 = digitsArr.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
            foreach (var d in q5_8)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("\n=========================================================================\n");

            // =========================================================================
            // PART 6: LINQ - Transformation Operators (Select)
            // =========================================================================
            Console.WriteLine("                   PART 6: TRANSFORMATION OPERATORS                      ");
            Console.WriteLine("=========================================================================");

            // --- Question 1: Select product names ---
            Console.WriteLine("\n--- Q1: Product names ---");
            var q6_1 = products.Select(p => p.ProductName);
            foreach (var name in q6_1)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 2: Upper and lower versions of words ---
            Console.WriteLine("--- Q2: Upper and lower versions of words ---");
            string[] wordsTransform = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var q6_2 = wordsTransform.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            foreach (var item in q6_2)
            {
                Console.WriteLine($"Upper: {item.Upper}, Lower: {item.Lower}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 3: Select product properties and rename Price ---
            Console.WriteLine("--- Q3: Product properties with renamed Price ---");
            var q6_3 = products.Select(p => new
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.UnitPrice
            });
            foreach (var item in q6_3)
            {
                Console.WriteLine($"ID: {item.ProductID}, Name: {item.ProductName}, Price: {item.Price:C}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 4: Check if array numbers match their positions ---
            Console.WriteLine("--- Q4: Number position matching check ---");
            int[] numbersMatch = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q6_4 = numbersMatch.Select((num, index) => new
            {
                Number = num,
                InPlace = (num == index)
            });
            foreach (var item in q6_4)
            {
                Console.WriteLine($"{item.Number}: InPlace = {item.InPlace}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 5: Pairs from numbersA and numbersB where A < B ---
            Console.WriteLine("--- Q5: Pairs (A < B) from two arrays ---");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var q6_5 = from a in numbersA
                       from b in numbersB
                       where a < b
                       select new { A = a, B = b };
            foreach (var pair in q6_5)
            {
                Console.WriteLine($"{pair.A} is less than {pair.B}");
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 6: Orders where Total < 500.00 ---
            Console.WriteLine("--- Q6: Orders where Total < 500.00 ---");
            var q6_6 = customers.SelectMany(c => c.Orders)
                                .Where(o => o.Total < 500.00m);
            foreach (var order in q6_6)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("\n-------------------------------------------------------------------------\n");

            // --- Question 7: Orders made in 1998 or later ---
            Console.WriteLine("--- Q7: Orders made in 1998 or later ---");
            var q6_7 = customers.SelectMany(c => c.Orders)
                                .Where(o => o.OrderDate.Year >= 1998);
            if (!q6_7.Any())
            {
                Console.WriteLine("No orders found from 1998 or later in current data.");
            }
            else
            {
                foreach (var order in q6_7)
                {
                    Console.WriteLine(order);
                }
            }

            Console.WriteLine("\n=========================================================================\n");
            Console.WriteLine("End of LINQ Assignment Solution");
            Console.WriteLine("=========================================================================");

            Console.ReadLine(); // Keep console window open
        }
    }
}