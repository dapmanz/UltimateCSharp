// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class FullName
{
    public string First { get; init; }
    public string Last { get; init; }

    public override string ToString() => $"{First} {Last}";

    //your code goes here
    public override bool Equals(object? obj)
    {
        return obj is FullName name &&
               First == name.First &&
               Last == name.Last;
    }
}
