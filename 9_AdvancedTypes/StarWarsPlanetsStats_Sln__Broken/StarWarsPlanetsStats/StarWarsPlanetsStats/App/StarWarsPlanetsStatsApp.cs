using StarWarsPlanetsStats.DataAccess;

namespace StarWarsPlanetsStats.App;

public class StarWarsPlanetsStatsApp(IPlanetsReader planetsReader,
    IPlanetsStatisticsAnalyzer planetsStatisticsAnalyzer,
    IUserInteractor userInteractor)
{
    private readonly IPlanetsReader _planetsReader = planetsReader;
    private readonly IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer = planetsStatisticsAnalyzer;
    private readonly IUserInteractor _userInteractor = userInteractor;

    public async Task RunAsync()
    {
        var baseAddress = "https://swapi.dev/api/";
        var requestUri = "planets/";

        var planets = await _planetsReader.Read(baseAddress, requestUri);

        foreach (var planet in planets)
        {
            _userInteractor.ShowMessage(planet.ToString());
        }

        _planetsStatisticsAnalyzer.Analyze(planets);
    }
}
