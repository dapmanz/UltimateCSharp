
using System.Numerics;

public record PlanetData : IPlanetData
{
    public string name;
    public double? population;
    public int diameter;
    public int? surface_water;

    public PlanetData(string _name, double? _population,
        int _diameter, int? _surface_water)
    {
        name = _name;
        population = _population;
        diameter = _diameter;
        surface_water = _surface_water;
    }

    public override string ToString()
    {
        //return string.Join(Environment.NewLine, $"{name} {population}" +
        //    $" {diameter} {surface_water}");
        return $"Name: {name}, Population: {population}, " +
        $"Diameter: {diameter}, Surface Water Percentage: {surface_water}";
    }

    public Dictionary<string, double?> Analyse(List<PlanetData> planets, string toAnalyse)
    {
        Dictionary<string, double?> planetDict = [];

        switch (toAnalyse.ToLower())
        {
            case "population":
                foreach (var planet in planets)
                {
                    planetDict.Add(planet.name, planet.population);
                }
                break;

            case "diameter":
                foreach (var planet in planets)
                {
                    planetDict.Add(planet.name, planet.diameter);
                }
                break;

            case "surface water":
                foreach (var planet in planets)
                {
                    planetDict.Add(planet.name, planet.surface_water);
                }
                break;

            default:
                throw new InvalidOperationException($"{toAnalyse} is not an expected input.");
        }

        var sortedDict = planetDict.OrderBy(x => x.Value).Where(x => x.Value != null);
        var maxPopulation = sortedDict.Last();
        var minPopulation = sortedDict.First();


        return new Dictionary<string, double?>()
        {
            [maxPopulation.Key] = maxPopulation.Value,
            [minPopulation.Key] = minPopulation.Value
        };
    }

}


