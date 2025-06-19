class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, double minutes, int laps) : base(date, minutes)
    {
        _activityName = "Swimming";
        _laps = laps;
    }

    public override double CalculateDistance()
    {
        return _laps / 20;
    }
    public override double CalculateSpeed()
    {
        return 3 * _laps / _minutes;
    }
    public override double CalculatePace()
    {
        return 20 * _minutes / _laps;
    }
}