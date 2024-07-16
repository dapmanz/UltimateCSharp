namespace StarWarsPlanetsStats.Utilities
{
    public static class StringExtensions
    {
        public static int? ToIntOrNull(this string? input)
        {
            return int.TryParse(input, out int inputParsed) ? inputParsed : null;
        }
    }
}
