public class Falidator
{
    public bool Falidate(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type.GetProperties()
                                        .Where(property => 
                                        Attribute.IsDefined(property, typeof(StringLengthValidateAttribute)));

        foreach (var property in propertiesToValidate)
        {
            object? propertyValue = property.GetValue(obj);
            if (propertyValue is not string)
            {
                throw new InvalidOperationException(
                    $"Attribute {nameof(StringLengthValidateAttribute)}" +
                    "can only be applied to strings.");
            }

            var value = (string)propertyValue;
            var attribute = (StringLengthValidateAttribute)property
                                .GetCustomAttributes(typeof(StringLengthValidateAttribute), true).First();

            if (value.Length < attribute.Min || value.Length > attribute.Max)
            {
                Console.WriteLine($"Property {property.Name} is invalid. Value is {value}");
                return false;
            }
        }
        return true;
    }
}