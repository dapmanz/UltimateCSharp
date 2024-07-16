
Console.WriteLine("Exercise 52: Params Keyword");

var stack = new Stack<string>();
stack.Push("fox");
stack.Push("cat");
stack.Push("wolf");

var result = stack.DoesContainAny("cow", "cat");
Console.ReadKey();

public static class StackExtensions
{
    public static bool DoesContainAny(this Stack<string>str, params string[] words)
    {
        var result = false;

        foreach (var word in words)
        {
            if (str.Contains(word))
                result = true;
        }

        return result;
    }
}
