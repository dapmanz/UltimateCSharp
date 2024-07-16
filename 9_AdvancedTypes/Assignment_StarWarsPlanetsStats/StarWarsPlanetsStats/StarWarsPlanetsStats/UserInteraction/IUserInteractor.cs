namespace StarWarsPlanetsStats.UserInteraction;

public interface IUserInteractor
{
    string ProcessInput();
    void Prompt();
    string BuildResponse(string userChoice, Dictionary<string, double?> transformedPlanetData);
    void DisplayMessage(string message);
}