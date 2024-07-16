var wordList = new List<string> { "aaa", "b", "c", "dd" };

Console.WriteLine(FindShortestWord(wordList));

string FindShortestWord(List<string> words)
{
    //your code goes here
    return words.OrderBy(word => word.Length)
                .First();
}
