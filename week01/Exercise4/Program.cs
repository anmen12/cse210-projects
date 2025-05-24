using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        while (true)
        {
            Console.WriteLine("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }

        int sum = Sum(numbers);
        Console.WriteLine($"The sum is: {sum}");

        int average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int largest = LargestNumber(numbers);
        Console.WriteLine($"The largest number is: {largest}");
    }

    static int Sum(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    static int LargestNumber(List<int> numbers)
    {
        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }
        return largest;
    }
}