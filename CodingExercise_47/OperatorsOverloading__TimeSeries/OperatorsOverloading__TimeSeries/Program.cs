var time1 = new Time(11, 15) + new Time(1, 10);
var time2 = new Time(11, 15) + new Time(1, 55);
var time3 = new Time(11, 15) + new Time(15, 10);

Console.WriteLine(time1);
Console.WriteLine(time2);
Console.WriteLine(time3);

public struct Time
{
    public int Hour { get; }
    public int Minute { get; }

    public Time(int hour, int minute)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(
                "Minute is out of range of 0-59");
        }
        Hour = hour;
        Minute = minute;
    }

    public override string ToString() =>
        $"{Hour.ToString("00")}:{Minute.ToString("00")}";

    //your code goes here      
    public static bool operator ==(Time left, Time right)
    {
        return left.Equals(right) ;
    }

    public static bool operator !=(Time left, Time right)
    {
        return !left.Equals(right);
    }

    public static Time operator +(Time left, Time right)
    {
        var minute = left.Minute + right.Minute;
        var hour = left.Hour + right.Hour;
        if (minute > 59)
        {
            hour += 1;
            minute -= 60;
        }
        if (hour > 23)
        {
            hour -= 24;
        }
        return new Time(hour, minute);
    }
}

