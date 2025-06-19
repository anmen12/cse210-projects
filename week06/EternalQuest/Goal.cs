abstract class Goal
{
    protected List<Event> _events = new List<Event>();
    protected string _name;
    protected bool _IsCompleted = false;

    public Goal()
    {
    }
    public Goal(string name)
    {
        _name = name;
    }
    public Goal(string name, bool IsCompleted)
    {
        _name = name;
        _IsCompleted = IsCompleted;
    }
    public List<Event> GetEvents()
    {
        return _events;
    }
    public bool IsCompleted()
    {
        return _IsCompleted;
    }

    protected void Complete()
    {
        _IsCompleted = true;
    }

    public abstract string GetDisplayText();
    protected abstract string GetCompletionStatus();

    public void AskUserForName()
    {
        Console.Write("What is the Name of Your Goal?\n > ");
        _name = Console.ReadLine();
    }
    public abstract void AskUserForPoints();
    public abstract void AddEvent();

    public void LoadEvent(string name, int points)
    {
        _events.Add(new Event(name, points));
    }

    public abstract string SaveGoal();
}