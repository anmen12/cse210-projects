using System.Data.SqlTypes;

class BreathingActivity : Activity
{
    public void RunActivity()
    {
        RunIntroduction("Welcome to the Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        BreathInAndOut();
        RunEnding("Breathing Activity");
    }

    private void BreathInAndOut()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_length);

        Breath("Breath in...", 2);
        Breath("Now breath out...", 3);
        Console.WriteLine();

        while (DateTime.Now <= endTime)
        {
            Breath("Breath in...", 4);
            Breath("Now breath out...", 6);
            Console.WriteLine();
        }
    }
    private void Breath(string text, int length)
    {
        Console.Write(text);
        for (int i = 0; i < length; i++)
        {
            Console.Write(length - i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}