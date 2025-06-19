class SimpleGoal : Goal
{
    private int _points;

    public SimpleGoal()
    {
    }
    public SimpleGoal(string name, bool IsCompleted, int points) : base(name, IsCompleted)
    {
        _points = points;
    }

    public override string GetDisplayText()
    {
        return $"[{GetCompletionStatus()}] {_name} - {_points} points";
    }
    protected override string GetCompletionStatus()
    {
        if (IsCompleted())
        {
            return "X";
        }
        return "_";
    }
    public override void AskUserForPoints()
    {
        Console.Write("How Many Points Should You Earn to Complete This Goal?\n > ");
        _points = int.Parse(Console.ReadLine());
    }
    public override void AddEvent()
    {
        Console.Write("How Have You Progressed In This Goal?\n > ");
        string eventName = Console.ReadLine();

        Console.WriteLine("Do You Think You Have Accomplished This Goal?");
        Console.WriteLine("    1. Yes");
        Console.WriteLine("    2. Not Yet");
        Console.Write("    (Answer 1-2): ");
        string eventCompletion = Console.ReadLine();

        int pointsEarned = 0;
        if (eventCompletion == "1")
        {
            Complete();
            pointsEarned = _points;
        }

        _events.Add(new Event(eventName, pointsEarned));
    }

    public override string SaveGoal()
    {
        string saveString = "Simple";
        saveString += $"~|~{_name}";
        saveString += $"~|~{_IsCompleted}";
        saveString += $"~|~{_points}";

        string saveEvents = "";
        foreach (Event _event in _events)
        {
            saveEvents += $"{_event.SaveEvent()}~||~";
        }
        for (int i = 0; i < 4; i++)
        {
            saveEvents = saveEvents.Remove(saveEvents.Length - 1);
        }
        saveString += $"~|~{saveEvents}";

        return saveString;
    }
}