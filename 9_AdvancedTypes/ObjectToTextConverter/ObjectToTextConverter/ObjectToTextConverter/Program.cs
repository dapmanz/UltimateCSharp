var converter = new ObjectToTypeConverter();
var ob = converter.Convert(
    new House("123 Maple Road", 170.6, 2));

Console.WriteLine(ob);

class ObjectToTypeConverter
{
    public string Convert(object obj)
    {
        Type type = obj.GetType();
        var properties = type.GetProperties()
                            .Where(property => property.Name != "EqualityContract");
        return String.Join(", ",  
            properties.Select(property => $"{property.Name} is {property.GetValue(obj)}"));
    }
}

public record Pet(string Name, PetType PetType, float Weight);
public record House(string Address, double Area, int Floors);
public enum PetType { Cat, Dog, Fish }