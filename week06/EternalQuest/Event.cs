class Event
{
    private string _name;
    private int _pointsEarned;
    public Event(string name, int pointsEarned)
    {
        _name = name;
        _pointsEarned = pointsEarned;
    }
    public int GetPointsEarned()
    {
        return _pointsEarned;
    }
    public string GetDisplayText()
    {
        return $"    {_pointsEarned} : {_name}";
    }

    public string SaveEvent()
    {
        return $"{_name}~|||~{_pointsEarned}";
    }
}