using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.App;

public class PlanetsStatisticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatisticsAnalyzer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }
    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNamesToSelectorMapping =
            new Dictionary<string, Func<Planet, int?>>
            {
                ["Population"] = planet => planet.Population,
                ["Surface water"] = planet => planet.SurfaceWater,
                ["Diameter"] = planet => planet.Diameter,
            };

        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage("The statistics of which property would you like to see?");
        _userInteractor.ShowMessage(string.Join(Environment.NewLine,
            propertyNamesToSelectorMapping.Keys));
        _userInteractor.ShowMessage(Environment.NewLine);

        var userChoice = _userInteractor.ReadFromUser();

        if (userChoice is null ||
            !propertyNamesToSelectorMapping.TryGetValue(userChoice, out Func<Planet, int?>? value))
        {
            _userInteractor.ShowMessage("Invalid User Choice");
        }
        else
        {
            ShowStatistics(planets, userChoice, value);
        }
    }

    private void ShowStatistics(IEnumerable<Planet> planets,
        string propertyName,
        Func<Planet, int?> propertySelector)
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySelector),
            propertySelector,
            propertyName);

        ShowStatistics(
            "Min",
            planets.MinBy(propertySelector),
            propertySelector,
            propertyName);
    }

    private void ShowStatistics(string descriptor, Planet selectedPlanet, Func<Planet, int?> propertySelector, string propertyName)
    {
        _userInteractor.ShowMessage($"{descriptor} {propertyName} is:" +
            $"{propertySelector(selectedPlanet)} " +
            $"(planet: ({selectedPlanet.Name})");
    }
}
