// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Exercise
{
    public Func<string, int> GetLength = n => n.Length; // your code goes here;
    public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(1, 11); // your code goes here;
}
