// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Exercise
{
    public void TestMethod()
    {
        /*your code goes here*/ Func<int, bool, double> someMethod1 = Method1;
        /*your code goes here*/ Func<DateTime> someMethod2 = Method2;
        /*your code goes here*/ Action<string, string> someMethod3 = Method3;
    }

    public double Method1(int a, bool b) => 0;
    public DateTime Method2() => default(DateTime);
    public void Method3(string a, string b) { }
}
