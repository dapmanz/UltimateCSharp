// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var firstSet = new List<string> { "hello", "There    " };
var secondSet = new List<string> { "hello", "    " };

Console.WriteLine(IsAnyWordWhiteSpace(firstSet));
Console.WriteLine(IsAnyWordWhiteSpace(secondSet));

bool IsAnyWordWhiteSpace(List<string> words)
{
    //your code goes here
    return words.Any(word => string.IsNullOrWhiteSpace(word));
}
