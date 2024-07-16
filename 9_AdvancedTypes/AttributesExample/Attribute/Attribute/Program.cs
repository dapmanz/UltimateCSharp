using System.ComponentModel.DataAnnotations;

var validPerson = new Person("John", 1981);
var invalidDog = new Dog("R");

var falidator = new Falidator();

Console.WriteLine(falidator.Falidate(validPerson) ?
    "Person is valid":
    "Person is invalid");

Console.WriteLine(falidator.Falidate(invalidDog) ?
    "Dog is valid" :
    "Dog is invalid");

Console.ReadKey();

public class Dog
{
    [StringLengthValidate(2, 10)]
    public string Name { get; }  // Length must be between 2 and 10

    public Dog(string name) => Name = name;
}

public class Person
{
    [StringLengthValidate(2, 25)]
    public string Name { get; } // Length must be between 2 and 25
    public int YearOfBirth { get; }

    public Person(string name, int yearOfBirth)
    {
        this.Name = name;
        this.YearOfBirth = yearOfBirth;
    }

    public Person(string name) => this.Name = name;
}

[AttributeUsage(AttributeTargets.Property)]
class StringLengthValidateAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public StringLengthValidateAttribute(int min, int max)
    {
        Min = min; 
        Max = max;   
    }
}


