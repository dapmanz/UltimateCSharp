 using StarWarsPlanetsStats;
using StarWarsPlanetsStats.UserInteraction;
using System.Text.Json;
using System.Xml.Linq;

try
{
    string name = string.Empty;
    double? population = default;
    int diameter = default;
    int? surface_water = default;


    var App = new StarWarsPlanetsStatsApp(new PlanetInfo(),
        new ApiDataReader(),
        new ConsoleUserInteractor(),
        new PlanetData(name, population, diameter, surface_water));

    await App.RunAsync();

}
catch (Exception ex)
{

	Console.WriteLine($"Sorry! The application has experienced an unexpected error {ex}" +
        "and will have to be closed.");
}

Console.ReadKey();


