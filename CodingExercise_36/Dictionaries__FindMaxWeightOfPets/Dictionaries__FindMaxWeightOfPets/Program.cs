// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var inputList = new List<Pet>()
                {
                    new Pet(PetType.Dog, weight: 10),
                    new Pet(PetType.Cat, weight: 5),
                    new Pet(PetType.Fish, weight: 0.9),
                    new Pet(PetType.Dog, weight: 45),
                    new Pet(PetType.Cat, weight: 2),
                    new Pet(PetType.Fish, weight: 0.02),
                };

var maxWeights = FindMaxWeights(inputList);

Console.ReadKey();


static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
{
    //your code goes here
    // Group by pet type
    var petsGroupedByType = new Dictionary<PetType, List<Pet>>();
    foreach (var pet in pets)
    {
        if (!petsGroupedByType.ContainsKey(pet.PetType))
        {
            petsGroupedByType[pet.PetType] = new List<Pet>();
        }
        petsGroupedByType[pet.PetType].Add(pet);
    }
    var result = new Dictionary<PetType, double>();

    // for each group
    foreach (var petGroup in petsGroupedByType)
    {
        // find max weight.
        double maxWeight = default;

        foreach (var pet in petGroup.Value)
        {
            if (pet.Weight > maxWeight)
            {
                maxWeight = pet.Weight;
            }
        }
        result[petGroup.Key] = maxWeight;
    }

    return result;
}
    
    public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }