using StarWarsPlanetsStats.UserInteraction;
using System.Text.Json;

public class StarWarsPlanetsStatsApp
{
    public readonly IPlanetInfo _planetInfo;
    public readonly IApiDataReader _apiDataReader;
    public readonly IUserInteractor _userInteractor;
    public readonly IPlanetData _planetData;

    public StarWarsPlanetsStatsApp(IPlanetInfo planetInfo, 
        IApiDataReader apiDataReader,
        IUserInteractor userInteractor,
        IPlanetData planetData)
    {
        _planetInfo = planetInfo;
        _apiDataReader = apiDataReader;
        _userInteractor = userInteractor;
        _planetData = planetData;
    }
    public async Task RunAsync()
    {
        var baseAddress = "https://swapi.dev/api/";
        var requestUri = "planets/";

        var json = await _apiDataReader.Read(baseAddress, requestUri);
        var root = JsonSerializer.Deserialize<Root>(json);
        List<PlanetData> planets = _planetInfo.Get(root);
        //_planetInfo.Display(planets);
        foreach (var planet in planets)
        {
            _userInteractor.DisplayMessage(planet.ToString());
        }

        _userInteractor.Prompt();
        string? userChoice = _userInteractor.ProcessInput();
        var transformedPlanetData = _planetData.Analyse(planets, userChoice);

        string response = _userInteractor.BuildResponse(userChoice, transformedPlanetData);
        _userInteractor.DisplayMessage(response);
    }

    

}


