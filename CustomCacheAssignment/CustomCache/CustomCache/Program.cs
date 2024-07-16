// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IDataDownloader dataDownloader = new SlowDataDownloader();

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    private readonly Cache<string, string> cache = new Cache<string, string>();
    public string DownloadData(string resourceId)
    {
        string idData = $"Some data for {resourceId}";

        if (!cache.cacheData.ContainsKey(resourceId))
        {
            cache.cacheData.Add(resourceId, idData);
            //let's imagine this method downloads real data,
            //and it does it slowly
            Thread.Sleep(1000);

            return idData;
        }
        else
            return cache.cacheData[resourceId];
    }
}

public class Cache<TKey, TValue>
{
    public Dictionary<TKey, TValue> cacheData = new Dictionary<TKey, TValue>();
}
