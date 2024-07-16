using System.Collections;

var customCollection = new CustomCollection(new string[] { "aaa", "bbb", "ccc" });

// IEnumerator<string> enumerator = customCollection.GetEnumerator();

var first = customCollection[0];
customCollection[1] = "zzz";

foreach (var word in customCollection)
{
    Console.WriteLine(word);
}

Console.ReadKey();

public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }

    public CustomCollection()
    {
        Words = new string[10];
    }
    public CustomCollection(string[] words) 
    { 
        Words = words; 
    }

    public string this[int index]
    {
        get => Words[0];
        set => Words[index] = value;
    }

    IEnumerator IEnumerable.GetEnumerator() 
    { 
        return GetEnumerator();
    }
    public IEnumerator<string> GetEnumerator()
    {        
        return new WordsEnumerator(Words);       
    }
}

public class WordsEnumerator : IEnumerator<string>
{
    private const int initialPosition = -1;
    private int _currentPosition = initialPosition;
    private readonly string[] _words;
    public WordsEnumerator(string[] words)
    {
        _words = words;
    }

    object IEnumerator.Current => Current;
    public string Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(CustomCollection)}'s end reached.", ex);
            }
        }
    }
    public bool MoveNext()
    {
        ++_currentPosition;
        return _currentPosition < _words.Length;
    }
    public void Reset()
    {
        _currentPosition = 0;
    }

    public void Dispose()
    {
    }
}