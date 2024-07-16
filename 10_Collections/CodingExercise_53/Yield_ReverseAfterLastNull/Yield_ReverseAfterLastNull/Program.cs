// See https://aka.ms/new-console-template for more information
using System.Xml;

Console.WriteLine("Hello, World!");

var input = new List<string?>() { "a", "b", null, "d", "e", "f", null, "h", "i" };

var output = GetAllAfterLastNullReversed(input);

foreach (var item in output)
    Console.WriteLine(item);

static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
{
    //your code goes here
    var stack = new Stack<T>();

    foreach (var item in input)
    {
       stack.Push(item);  
    }

    foreach (var item in stack)
    {
        if (item is not null)
        {
            yield return item;
        }
        else
        {
            yield break;
        }
    }
}
