class EternalGoal : Goal
{
    private int _timesDone = 0;
    private int _pointsEarnedEachTime;
    private int _bonusPointSeperation = 0;
    private int _bonusPoints = 0;
    private int _totalPointsEarned;

    public EternalGoal()
    {
    }
    public EternalGoal(string name, int timesDone, int pointsEarnedEachTime, int bonusPointSeperation, int bonusPoints, int totalPointsEarned) : base(name)
    {
        _timesDone = timesDone;
        _pointsEarnedEachTime = pointsEarnedEachTime;
        _bonusPointSeperation = bonusPointSeperation;
        _bonusPoints = bonusPoints;
        _totalPointsEarned = totalPointsEarned;
    }

    public override string GetDisplayText()
    {
        return $"[{GetCompletionStatus()}] {_name} - {_totalPointsEarned} total points";
    }
    protected override string GetCompletionStatus()
    {
        return _timesDone.ToString();
    }
    public override void AskUserForPoints()
    {
        Console.Write("How Many Points Should You Earn Each Time You Complete This Goal?\n > ");
        _pointsEarnedEachTime = int.Parse(Console.ReadLine());

        Console.Write("After How Many Times Should You Earn Bonus Points (Enter 0 for No Bonus Points)?\n > ");
        _bonusPointSeperation = int.Parse(Console.ReadLine());

        if (_bonusPointSeperation != 0)
        {
            Console.Write($"How Many Bonus Points Should You Earn After Every {_bonusPointSeperation} Times?\n > ");
            _bonusPoints = int.Parse(Console.ReadLine());
        }
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
            if (_bonusPointSeperation != 0)
            {
                if (_timesDone % _bonusPointSeperation == 0)
                {
                    pointsEarned += _bonusPoints;
                }
            }
            pointsEarned += _pointsEarnedEachTime;
            _totalPointsEarned += pointsEarned;
        }

        _events.Add(new Event(eventName, pointsEarned));
    }

    public override string SaveGoal()
    {
        string saveString = "Eternal";
        saveString += $"~|~{_name}";
        saveString += $"~|~{_timesDone}";
        saveString += $"~|~{_pointsEarnedEachTime}";
        saveString += $"~|~{_bonusPointSeperation}";
        saveString += $"~|~{_bonusPoints}";
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