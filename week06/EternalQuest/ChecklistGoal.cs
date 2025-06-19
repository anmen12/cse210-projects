class ChecklistGoal : Goal
{
    private int _timesDone = 0;
    private int _pointsEarnedEachTime;
    private int _timesToFinish = 0;
    private int _finishPoints = 0;
    private int _totalPointsEarned;

    public ChecklistGoal()
    {
    }
    public ChecklistGoal(string name, bool IsCompleted, int timesDone, int pointsEarnedEachTime, int timesToFinish, int finishPoints, int totalPointsEarned) : base(name, IsCompleted)
    {
        _timesDone = timesDone;
        _pointsEarnedEachTime = pointsEarnedEachTime;
        _timesToFinish = timesToFinish;
        _finishPoints = finishPoints;
        _totalPointsEarned = totalPointsEarned;
    }

    public override string GetDisplayText()
    {
        return $"[{GetCompletionStatus()}] {_name} - {_totalPointsEarned} total points";
    }
    protected override string GetCompletionStatus()
    {
        return $"{_timesDone}/{_timesToFinish}";
    }
    public override void AskUserForPoints()
    {
        Console.Write("How Many Points Should You Earn Each Time You Complete This Goal?\n > ");
        _pointsEarnedEachTime = int.Parse(Console.ReadLine());

        Console.Write("How Many Times Do You Want To Do This Goal\n > ");
        _timesToFinish = int.Parse(Console.ReadLine());

        Console.Write($"How Many Points Should You Earn At The End?\n > ");
        _finishPoints = int.Parse(Console.ReadLine());
    }
    public override void AddEvent()
    {
        Console.Write("How Have You Progressed In This Goal?\n > ");
        string eventName = Console.ReadLine();

        Console.WriteLine("Do You Think You Have Accomplished This Goal Once?");
        Console.WriteLine("    1. Yes");
        Console.WriteLine("    2. Not Yet");
        Console.Write("    (Answer 1-2): ");
        string eventCompletion = Console.ReadLine();

        int pointsEarned = 0;
        if (eventCompletion == "1")
        {
            //calculate points
            _timesDone++;
            if (_timesToFinish != 0)
            {
                if (_timesDone >= _timesToFinish)
                {
                    Complete();
                    pointsEarned += _finishPoints;
                }
            }
            pointsEarned += _pointsEarnedEachTime;
            _totalPointsEarned += pointsEarned;
        }

        _events.Add(new Event(eventName, pointsEarned));
    }

    public override string SaveGoal()
    {
        string saveString = "Checklist";
        saveString += $"~|~{_name}";
        saveString += $"~|~{_IsCompleted}";
        saveString += $"~|~{_timesDone}";
        saveString += $"~|~{_pointsEarnedEachTime}";
        saveString += $"~|~{_timesToFinish}";
        saveString += $"~|~{_finishPoints}";
        saveString += $"~|~{_totalPointsEarned}";

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