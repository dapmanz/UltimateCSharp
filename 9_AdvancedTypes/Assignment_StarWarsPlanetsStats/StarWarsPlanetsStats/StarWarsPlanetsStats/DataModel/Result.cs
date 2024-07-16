using System.Text.Json.Serialization;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Result(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("rotation_period")] string rotation_period,
    [property: JsonPropertyName("orbital_period")] string orbital_period,
    [property: JsonPropertyName("diameter")] string diameter,
    [property: JsonPropertyName("climate")] string climate,
    [property: JsonPropertyName("gravity")] string gravity,
    [property: JsonPropertyName("terrain")] string terrain,
    [property: JsonPropertyName("surface_water")] string surface_water,
    [property: JsonPropertyName("population")] string population,
    [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
    [property: JsonPropertyName("films")] IReadOnlyList<string> films,
    [property: JsonPropertyName("created")] DateTime created,
    [property: JsonPropertyName("edited")] DateTime edited,
    [property: JsonPropertyName("url")] string url
)
{
    public static implicit operator PlanetData(Result result)
    {
        string name = result.name;

        double? population;
        if (result.population == "unknown")
        {
            population = null;
        }
        else
        {
            population = double.Parse(result.population);
        }

        int diameter = int.Parse(result.diameter);
        int? surface_water;

        if (result.surface_water == "unknown")
        {
            surface_water = null;
        }
        else
        {
            surface_water = int.Parse(result.surface_water);
        }

        return new PlanetData(name, population, diameter, surface_water);
    }
}
;


