// In addition to the core requirements, I added code to let the user look at their usage rates for
// each exercise

using System;
using System.Formats.Asn1;

class Program
{
    static List<int> usageRates = [0, 0, 0];

    static void Main(string[] args)
    {
        string answer = "";
        //main loop
        while (answer != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Start breathing activity");
            Console.WriteLine("    2. Start reflecting activity");
            Console.WriteLine("    3. Start listing activity");
            Console.WriteLine("    4. List Usage Rates");
            Console.WriteLine("    5. Quit");
            Console.Write("Select a choice from the menu: ");
            answer = Console.ReadLine();
            switch (answer)
            {
                case "1": //breathing activity
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.RunActivity();
                    usageRates[0]++;
                    break;
                case "2": //reflecting activity
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.RunActivity();
                    usageRates[1]++;
                    break;
                case "3": //listing activity
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.RunActivity();
                    usageRates[2]++;
                    break;
                case "4": //list usage rates
                    ListUsageRates();
                    break;
                default:
                    break;
            }
        }
    }

    static void ListUsageRates()
    {
        Activity spinner = new Activity();
        Console.Clear();
        Console.WriteLine($"You have done the Breathing Activity {usageRates[0]} times.");
        Console.WriteLine($"You have done the Reflecting Activity {usageRates[1]} times.");
        Console.WriteLine($"You have done the Listing Activity {usageRates[2]} times.");
        Console.WriteLine();

        spinner.RunSpinner(13);
    }
}