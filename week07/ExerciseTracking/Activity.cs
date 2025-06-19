abstract class Activity
{
    protected string _date;
    protected string _activityName;
    protected double _minutes;
    protected Activity(string date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double CalculateDistance();
    public abstract double CalculateSpeed();
    public abstract double CalculatePace();

    public string GetSummary()
    {
        return $"{_date} {_activityName} ({_minutes.ToString("0")} min) - Distance: {CalculateDistance().ToString("0.0")} km, Speed: {CalculateSpeed().ToString("0.0")} kph, Pace: {CalculatePace().ToString("0.0")} min per km";
    }
}