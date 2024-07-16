// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class AllLinesFromTextFileReader : IDisposable// your code goes here
{
    private readonly StreamReader _streamReader;

    public AllLinesFromTextFileReader(string filePath)
    {
        _streamReader = new StreamReader(filePath, true); //your code goes here
    }


    public List<string> ReadAllLines()
    {
        var result = new List<string>();
        while (!_streamReader.EndOfStream)
        {
            result.Add(_streamReader.ReadLine());
        }

        return result;
    }


    //your code goes here
    public void Dispose()
    {
        _streamReader.Dispose();
    }
}