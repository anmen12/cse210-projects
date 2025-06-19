// In addition to the core requirements, the Eternal Goal can award points every x times it is
// completed as well as current and completed goals are stored seperately and are viewed
// seperately. The events are also recorded and can be accessed for each goal.

using System;
using System.ComponentModel.Design;
using System.Formats.Asn1;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static List<Goal> currentGoals = new List<Goal>();
    static List<Goal> completedGoals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        //main loop
        string answer = "";
        while (answer != "8")
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("    1. View Score");
            Console.WriteLine("    2. Add a New Goal");
            Console.WriteLine("    3. Update a Goal");
            Console.WriteLine("    4. Look at Current Goals");
            Console.WriteLine("    5. Look at Finished Goals");
            Console.WriteLine("    6. Load Goals");
            Console.WriteLine("    7. Save Goals");
            Console.WriteLine("    8. Exit Program");
            Console.Write("    (Answer 1-8): ");
            answer = Console.ReadLine();

            switch (answer)
            {
                case "1": //view score
                    Console.Clear();
                    ViewScore();
                    Console.Write("\nPress Enter to go Back to Main Menu");
                    Console.ReadLine();
                    break;
                case "2": //add goal
                    AddNewGoal();
                    break;
                case "3": //update goal
                    if (currentGoals.Count > 0)
                    {
                        UpdateGoal();
                    }
                    break;
                case "4": //list current goals
                    if (currentGoals.Count > 0)
                    {
                        Console.Clear();
                        ListGoals(currentGoals, true);
                        Console.Write("Press Enter to go Back to Main Menu");
                        Console.ReadLine();
                    }
                    break;
                case "5": //list completed goals
                    if (completedGoals.Count > 0)
                    {
                        Console.Clear();
                        ListGoals(completedGoals, true);
                        Console.Write("Press Enter to go Back to Main Menu");
                        Console.ReadLine();
                    }
                    break;
                case "6": //load goals
                    LoadFromFile(GetFileName());
                    break;
                case "7": //save goals
                    SaveToFile(GetFileName());
                    break;
                default:
                    break;
            }
        }
    }

    static void ViewScore()
    {
        Console.WriteLine($"Score: {score}");
    }
    static void AddNewGoal()
    {
        string answer = "";
        List<string> validAnswers = ["1", "2", "3", "4"];
        while (!validAnswers.Contains(answer))
        {
            Console.Clear();
            Console.WriteLine("What Type of Goal Would You Like to Create?");
            Console.WriteLine("    1. A Simple Goal");
            Console.WriteLine("    2. A Checklist Goal");
            Console.WriteLine("    3. An Eternal Goal");
            Console.WriteLine("    4. None");
            Console.Write("    (Answer 1-4): ");
            answer = Console.ReadLine();
            Console.Clear();

            switch (answer)
            {
                case "1":
                    currentGoals.Add(new SimpleGoal());
                    break;
                case "2":
                    currentGoals.Add(new ChecklistGoal());
                    break;
                case "3":
                    currentGoals.Add(new EternalGoal());
                    break;
                default:
                    break;
            }

            if (answer == "1" || answer == "2" || answer == "3")
            {
                currentGoals[currentGoals.Count - 1].AskUserForName();
                currentGoals[currentGoals.Count - 1].AskUserForPoints();
            }
        }



    }
    static void UpdateGoal()
    {
        Console.Clear();
        Console.WriteLine("Select a Goal to Update:");
        ListGoals(currentGoals);
        Console.Write($"    (Answer {1}-{currentGoals.Count}): ");
        int answer = int.Parse(Console.ReadLine());
        Console.Clear();

        if (answer > 0 && currentGoals.Count >= answer)
        {
            ListGoals([currentGoals[answer - 1]], true);

            currentGoals[answer - 1].AddEvent();

            //add points
            score += currentGoals[answer - 1].GetEvents()[currentGoals[answer - 1].GetEvents().Count - 1].GetPointsEarned();

            if (currentGoals[answer - 1].IsCompleted())
            {
                completedGoals.Add(currentGoals[answer - 1]);
                currentGoals.Remove(currentGoals[answer - 1]);
            }
        }

    }
    static void ListGoals(List<Goal> goals, bool showEvents = false)
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"    {i + 1}. {goals[i].GetDisplayText()}");
            if (showEvents)
            {
                Console.Write("    ");
                ListGoalEvents(goals[i], "    ");
            }
        }
    }
    static void ListGoalEvents(Goal goal, string buffer = "")
    {
        Console.WriteLine("Previous Events:");
        foreach (Event _event in goal.GetEvents())
        {
            Console.WriteLine($"{buffer}{_event.GetDisplayText()}");
        }
        Console.WriteLine();
    }

    static void LoadFromFile(string file)
    {
        currentGoals.Clear();
        completedGoals.Clear();

        string[] lines = File.ReadAllLines(file);

        score = int.Parse(lines[0]);

        List<Goal> allGoals = new List<Goal>();

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            if (parts[0] == "Simple")
            {
                Goal newGoal = new SimpleGoal(parts[1], StringToBool(parts[2]), int.Parse(parts[3]));

                string[] events = parts[4].Split("~||~");
                foreach (string _event in events)
                {
                    string[] eventParts = _event.Split("~|||~");
                    newGoal.LoadEvent(eventParts[0], int.Parse(eventParts[1]));
                }

                allGoals.Add(newGoal);
            }
            else if (parts[0] == "Checklist")
            {
                Goal newGoal = new ChecklistGoal(parts[1], StringToBool(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]));

                string[] events = parts[8].Split("~||~");
                foreach (string _event in events)
                {
                    string[] eventParts = _event.Split("~|||~");
                    newGoal.LoadEvent(eventParts[0], int.Parse(eventParts[1]));
                }

                allGoals.Add(newGoal);
            }
            else if (parts[0] == "Eternal")
            {
                Goal newGoal = new EternalGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));

                string[] events = parts[7].Split("~||~");
                foreach (string _event in events)
                {
                    string[] eventParts = _event.Split("~|||~");
                    newGoal.LoadEvent(eventParts[0], int.Parse(eventParts[1]));
                }

                allGoals.Add(newGoal);
            }
        }

        foreach (Goal goal in allGoals)
        {
            if (!goal.IsCompleted())
            {
                currentGoals.Add(goal);
            }
            else
            {
                completedGoals.Add(goal);
            }
        }
    }
    static void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine(score);
            foreach (Goal goal in currentGoals)
            {
                outputFile.WriteLine(goal.SaveGoal());
            }
            foreach (Goal goal in completedGoals)
            {
                outputFile.WriteLine(goal.SaveGoal());
            }
        }
    }
    static string GetFileName()
    {
        Console.WriteLine($"What is the filename?");
        return Console.ReadLine();
    }
    static bool StringToBool(string str)
    {
        if (str == "False")
        {
            return false;
        }
        return true;
    }
}