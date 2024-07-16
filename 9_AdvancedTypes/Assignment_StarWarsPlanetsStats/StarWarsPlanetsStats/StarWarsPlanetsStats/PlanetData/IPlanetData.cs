public interface IPlanetData
{
    Dictionary<string, double?> Analyse(List<PlanetData> planets, string toAnalyse);
    string ToString();
}