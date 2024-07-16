public class PlanetInfo : IPlanetInfo
{
    public List<PlanetData> Get(Root? root)
    {
        List<PlanetData> planets = new List<PlanetData>();
        foreach (var planet in root!.results)
        {
            planets.Add(planet);
        }
        return planets;
    }
}


