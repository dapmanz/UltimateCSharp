// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class SomeClass
{
    [MustBeLargerThan(100)]
    public int Value { get; }

}

[AttributeUsage(AttributeTargets.Property)]
public class MustBeLargerThanAttribute : Attribute
{
    public int Min {  get; }

    public MustBeLargerThanAttribute(int min)
    {
        Min = min;
    }
}