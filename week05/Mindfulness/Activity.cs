using System.Numerics;
using System.Runtime.CompilerServices;

class Activity
{
    protected int _length;

    protected void RunIntroduction(string welcomeMessage, string description)
    {
        Console.WriteLine(welcomeMessage);
        Console.WriteLine();

        Console.WriteLine(description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _length = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Get ready...");
        RunSpinner(4);
        Console.WriteLine();
    }
    protected void RunEnding(string activityName)
    {
        Console.WriteLine("Well done!!");
        RunSpinner(4);
        Console.WriteLine();

        Console.WriteLine($"You have completed another {_length} seconds of the {activityName}");
        RunSpinner(4);
        Console.WriteLine();
    }
    public void RunSpinner(int length)
    {
        List<string> loadingCircle = ["-", "\\", "|", "/"];

        for (int i = 0; i < length; i++)
        {
            foreach (string symbol in loadingCircle)
            {
                Console.Write(symbol);
                Thread.Sleep(125);
                Console.Write("\b \b");
            }
        }
    }
}