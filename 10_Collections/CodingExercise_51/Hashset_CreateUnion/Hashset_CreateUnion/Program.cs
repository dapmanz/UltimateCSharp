// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

var set1 = new HashSet<int>() { 1, 2, 3, 4, 5 };
var set2 = new HashSet<int>() { 4, 5, 6 };

var set3 = new HashSet<string>() { "a",  "b", "c" };
var set4 = new HashSet<string>() { "c", "d" };

var union = HashSetsUnionExercise.CreateUnion(set1, set2);
var union2 = HashSetsUnionExercise.CreateUnion(set3, set4);

foreach (var item in union2)
{
    Console.WriteLine(item);
}

public static class HashSetsUnionExercise
{
    public static HashSet<T> CreateUnion<T>(
        HashSet<T> set1, HashSet<T> set2)
    {
        //your code goes here
        
        var set = new HashSet<T>();
        set.UnionWith(set1);
        set.UnionWith(set2);

        return set;
    }
}
