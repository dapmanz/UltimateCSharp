using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStats.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public void Prompt()
    {
        Console.WriteLine();

        Console.WriteLine("The statistics of which property would you like to see? ");
        Console.WriteLine("population");
        Console.WriteLine("diameter");
        Console.WriteLine("surface water");
        Console.WriteLine();
    }

    public string ProcessInput()
    {
        string? userChoice;
        do
        {
            userChoice = Console.ReadLine();

        } while (userChoice is null);

        userChoice = userChoice.Trim().ToLower();
        return userChoice;
    }

    public string BuildResponse(string userChoice, Dictionary<string, double?> transformedPlanetData)
    {
        var maxPair = transformedPlanetData.First();
        var minPair = transformedPlanetData.Skip(1).First();
        var response = $"Max {userChoice} is {maxPair.Value} (planet: {maxPair.Key})" +
            Environment.NewLine +
            $"Min {userChoice} is {minPair.Value} (planet: {minPair.Key})";
        return response;
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message); ;
    }
}
