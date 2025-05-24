using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        while (true)
        {
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());

            if (guess == number)
            {
                Console.WriteLine("You guessed it!");
                break;
            }
            else if (guess >= number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }
        }
        
    }
}