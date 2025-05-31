using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        string answer = "";
        while (answer != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            answer = Console.ReadLine();

            switch (answer)
            {
                case "1": //write
                    myJournal.AddEntry(WriteEntry());
                    break;
                case "2": //display
                    myJournal.DisplayAll();
                    break;
                case "3": //load
                    myJournal.LoadFromFile(GetFileName());
                    break;
                case "4": //save
                    myJournal.SaveToFile(GetFileName());
                    break;
                case "5": //quit
                    break;
                default:
                    Console.WriteLine("--- Invalid Response ---");
                    Console.WriteLine($"");
                    break;
            }
        }
    }

    static Entry WriteEntry()
    {
        PromptGenerator myPromptGenerator = new PromptGenerator();
        Entry newEntry = new Entry();

        newEntry._date = DateTime.Today.ToString("d");

        newEntry._promptText = myPromptGenerator.GetRandomPrompt();
        Console.WriteLine($"{newEntry._promptText}");

        newEntry._entryText = Console.ReadLine();

        return newEntry;
    }

    static string GetFileName()
    {
        Console.WriteLine($"What is the filename?");
        return Console.ReadLine();
    }
}