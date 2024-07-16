var ts = new List<TimeSpan> {
    TimeSpan.FromMicroseconds(100),
    TimeSpan.FromMicroseconds(50),
    TimeSpan.FromMicroseconds(30),
};

Console.WriteLine(CalculateAverageDurationInMilliseconds(ts));

double CalculateAverageDurationInMilliseconds(IEnumerable<TimeSpan> timeSpans)
{
    //your code goes here
    return timeSpans.Average(tspan => tspan.TotalMilliseconds);
}