class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(string date, double minutes, double speed) : base(date, minutes)
    {
        _activityName = "Cycling";
        _speed = speed;
    }

    public override double CalculateDistance()
    {
        return _speed * _minutes / 60;
    }
    public override double CalculateSpeed()
    {
        return _speed;
    }
    public override double CalculatePace()
    {
        return 60 / _speed;
    }
}