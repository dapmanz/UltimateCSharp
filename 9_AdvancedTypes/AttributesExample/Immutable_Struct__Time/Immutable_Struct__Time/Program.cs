
var fivePastSeven = new Time(7, 5);
Console.WriteLine(fivePastSeven);

public struct Time
{
    public int Hour { get;  }
    public int Minute { get; }

    public Time(int hour, int minute)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException($"{nameof(hour)} is out of range");
        }
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException($"{nameof(minute)} is out of range");
        }
        Hour = hour;
        Minute = minute;
    }

    public override string ToString()
    {
        return $"{Hour.ToString("00")}:{Minute.ToString("00")}";
    }
}
