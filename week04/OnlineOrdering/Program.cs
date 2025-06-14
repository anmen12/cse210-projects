using System;
using System.Diagnostics.Metrics;

class Program
{
    static List<string> names = ["Adam", "Bill", "Bob", "Emma", "Jerry", "Luke", "Olivia", "Mia", "Sarah", "Sofia", "Tom", "Rose"];
    static List<string> streets = ["Main St", "1st St", "2nd St", "3rd St", "4th St", "Oak St", "Elm St"];
    static List<string> places = ["New York", "Amsterdam", "Salt Lake City", "Boston", "Paris", "London"];
    static List<string> countries = ["USA", "England", "France"];
    static List<string> products = [];

    static void Main(string[] args)
    {
        List<Order> orders = new List<Order>();

        Random randomGenerator = new Random();

        //create orders and customers
        for (int i = 0; i < 2; i++)
        {
            orders.Add(new Order(new Customer(GetRandomName(), new Address(GetRandomStreet(), GetRandomPlace(), GetRandomPlace(), GetRandomCountry()))));
        }

        //add products
        foreach (Order order in orders)
        {
            for (int i = randomGenerator.Next(0, 2); i < 3; i++)
            {
                var product = GetRandomProduct();
                order.AddProduct(product.Item1, product.Item2, product.Item3, product.Item4);
            }
        }

        //print packing and shipping labels and total prices
        foreach (Order order in orders)
        {
            //packing label
            Console.WriteLine("Packing Label");
            foreach (string product in order.GetPackingLabel())
            {
                Console.WriteLine($"    {product}");
            }
            //shipping label
            Console.WriteLine("Shipping Label");
            Console.WriteLine($"    {order.GetShippingLabel()}");
            //total price
            Console.WriteLine("Total Price");
            Console.WriteLine($"    ${order.GetTotalCost()}");

            Console.WriteLine();
        }
    }

    static string GetRandomName()
    {
        Random randomGenerator = new Random();
        return names[randomGenerator.Next(0, names.Count)];
    }
    static string GetRandomStreet()
    {
        Random randomGenerator = new Random();
        return streets[randomGenerator.Next(0, streets.Count)];
    }
    static string GetRandomPlace()
    {
        Random randomGenerator = new Random();
        return places[randomGenerator.Next(0, places.Count)];
    }
    static string GetRandomCountry()
    {
        Random randomGenerator = new Random();
        return countries[randomGenerator.Next(0, countries.Count)];
    }
    static (string, string, double, int) GetRandomProduct()
    {
        Random randomGenerator = new Random();
        var product = ("product", "id", randomGenerator.NextDouble() * 20, randomGenerator.Next(1, 11));
        return product;
    }
}