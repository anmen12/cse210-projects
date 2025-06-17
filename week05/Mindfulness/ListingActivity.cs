using System.Data.SqlTypes;

class ListingActivity : Activity
{
    private List<string> prompts = ["Who are people that you appreciate?",
                                    "What are personal strengths of yours?",
                                    "Who are people that you have helped this week?",
                                    "When have you felt the Holy Ghost this month?",
                                    "Who are some of your personal heroes?",
                                    "What made you feel happy today?"];
    private List<string> answers = new List<string>();
    public void RunActivity()
    {
        RunIntroduction("Welcome to the Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        PromptUser();
        ListItems();
        RunEnding("Listing Activity");
    }

    private void PromptUser()
    {
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {RandomPrompt()} --- ");
        Console.Write("You may begin in: ");
        for (int i = 0; i < 5; i++)
        {
            Console.Write(5 - i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
    private void ListItems()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_length);

        while (DateTime.Now <= endTime)
        {
            Console.Write("> ");
            answers.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {answers.Count} items!");
        Console.WriteLine();
    }
    private string RandomPrompt()
    {
        Random randomizer = new Random();
        return prompts[randomizer.Next(0,prompts.Count)];
    }
}