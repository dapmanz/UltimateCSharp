

IDataDownloader dataDownloader = new PrintingDownloader(
    new CachingDataDownloader(
        new SlowDataDownloader()));

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public class PrintingDownloader : IDataDownloader
{
    private readonly IDataDownloader _dataDownloader;
    private readonly Cache<string, string> _cache = new();

    public PrintingDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    public string DownloadData(string resourceId)
    {
        var data = _dataDownloader.DownloadData(resourceId);
        Console.WriteLine("Data is ready!");
        return data;
    }
}

public class CachingDataDownloader : IDataDownloader
{
    private readonly IDataDownloader _downloader;
    private readonly Cache<string, string> _cache = new();

    public CachingDataDownloader(IDataDownloader downloader)
    {
        _downloader = downloader;
    }

    public string DownloadData(string resourceId)
    {
        return _cache.Get(resourceId, _downloader.DownloadData);
    }
}

public class Cache<TKey, TData>
{
    private readonly Dictionary<TKey, TData> _cachedata = new();

    public TData Get(TKey key, Func<TKey, TData> getForTheFirstTime)
    { 
        if(!_cachedata.ContainsKey(key))
        {
            _cachedata[key] = getForTheFirstTime(key);
        }
        return _cachedata[key];
    }
}

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

