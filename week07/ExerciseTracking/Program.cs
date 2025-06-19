using System;

class Program
{
    static void Main(string[] args)
    {
        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        string date = $"{FormatDay(day)} {FormatMonth(month)} {FormatYear(year)}";

        List<Activity> activities = new List<Activity>();

        activities.Add(new RunningActivity(date, 30, 20));
        activities.Add(new RunningActivity(date, 60, 30));

        activities.Add(new CyclingActivity(date, 60, 25));
        activities.Add(new CyclingActivity(date, 180, 20));

        activities.Add(new SwimmingActivity(date, 60, 80));
        activities.Add(new SwimmingActivity(date, 120, 200));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

    static string FormatDay(int day)
    {
        if (day > 9)
        {
            return $"{day}";
        }
        return $"0{day}";
    }
    static string FormatMonth(int month)
    {
        switch (month)
        {
            case 1:
                return "Jan";
            case 2:
                return "Feb";
            case 3:
                return "Mar";
            case 4:
                return "Apr";
            case 5:
                return "May";
            case 6:
                return "Jun";
            case 7:
                return "Jul";
            case 8:
                return "Aug";
            case 9:
                return "Sep";
            case 10:
                return "Oct";
            case 11:
                return "Nov";
            case 12:
                return "Dec";
        }
        return "Non";
    }
    static string FormatYear(int year)
    {
        return $"{year}";
    }
}