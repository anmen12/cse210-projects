using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradeValue = int.Parse(Console.ReadLine());

        string letterGrade = Grade(gradeValue);
        Console.WriteLine();
        Console.WriteLine($"Your grade: {letterGrade}");
        if (gradeValue >= 70)
        {
            Console.WriteLine("Congrats on passing the class!");
        }
        else
        {
            Console.WriteLine("Try better next time.");
        }
    }

    static string Grade(int gradeValue)
    {
        if (gradeValue >= 90)
        {
            return "A";
        }
        else if (gradeValue >= 80)
        {
            return "B";
        }
        else if (gradeValue >= 70)
        {
            return "C";
        }
        else if (gradeValue >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}