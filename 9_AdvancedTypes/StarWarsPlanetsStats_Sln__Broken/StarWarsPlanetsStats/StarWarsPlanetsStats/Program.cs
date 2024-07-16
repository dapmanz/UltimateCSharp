using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.App;
using StarWarsPlanetsStats.DataAccess;

try
{
    await new StarWarsPlanetsStatsApp(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader(),
            new ConsoleUserInteractor()),
        new PlanetsStatisticsAnalyzer(
            new ConsoleUserInteractor()),
        new ConsoleUserInteractor()).RunAsync();
}
catch(Exception ex)
{
    new ConsoleUserInteractor().ShowMessage("An error occurred. Exception message" + ex.Message);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();

 