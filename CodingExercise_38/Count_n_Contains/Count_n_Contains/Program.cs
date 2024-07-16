
var numList = new List<List<int>> { 
    new List<int> {1, 2, 5, -1},
    new List<int> { 0, 4, 4, 6},
    new List<int> { 9, 0}};

Console.WriteLine(CountListsContainingZeroLongerThan(3, numList));
int CountListsContainingZeroLongerThan(
            int length,
            List<List<int>> listsOfNumbers)
{
    //your code goes here
    var listsWithZeros = new List<List<int>>();

    foreach (var listOfNumbers in listsOfNumbers)
    {
        if (listOfNumbers.Contains(0))
        {
            listsWithZeros.Add(listOfNumbers);
        }
    }

    return listsWithZeros.Count(listWithZeros => (listWithZeros.Count > length));

}
