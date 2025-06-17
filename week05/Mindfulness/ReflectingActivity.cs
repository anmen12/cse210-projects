using System.Data.SqlTypes;

class ReflectingActivity : Activity
{
    private List<string> prompts = ["Think of a time when you stood up for someone else",
                                    "Think of a time when you did something really difficult",
                                    "Think of a time when you helped someone in need",
                                    "Think of a time when you did something truly selfless",
                                    "Think of a time when you did something you've been putting off",
                                    "Think of a time when you found something you lost",
                                    "Think of a time when you smiled when you were sad",
                                    "Think of a time when you found spent time with someone"];
    private List<string> questions = ["Why was this experience meaningful to you?",
                                        "Have you ever done anything like this before?",
                                        "How did you get started?",
                                        "How did you feel when it was complete?",
                                        "What made this time different than other times when you were not as successful?",
                                        "What is your favorite thing about this experience?",
                                        "What could you learn from this experience that applies to other situations?",
                                        "What did you learn about yourself through this experience?",
                                        "How can you keep this experience in mind in the future?",
                                        "Do you want to do it again?",
                                        "How did you feel while doing it?"];
    public void RunActivity()
    {
        RunIntroduction("Welcome to the Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        PromptUser();
        Reflect();
        RunEnding("Reflecting Activity");
    }

    private void PromptUser()
    {
        Console.WriteLine("Consider the following Prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {RandomPrompt()} --- ");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        for (int i = 0; i < 5; i++)
        {
            Console.Write(5 - i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
    private void Reflect()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_length);

        while (DateTime.Now <= endTime)
        {
            Console.Write($"> {RandomQuestion()} ");
            RunSpinner(13);
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    private string RandomPrompt()
    {
        Random randomizer = new Random();
        return prompts[randomizer.Next(0,prompts.Count)];
    }
    private string RandomQuestion()
    {
        Random randomizer = new Random();
        return questions[randomizer.Next(0,questions.Count)];
    }
}