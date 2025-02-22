﻿namespace CookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        var allIngredientsWithGivenId = All.Where(ingredient => ingredient.Id == id);

        if(allIngredientsWithGivenId.Count() > 1 )
        {
            throw new InvalidOperationException(
                $"More than one ingredients have ID equal to {id}");
        }
        return allIngredientsWithGivenId.FirstOrDefault();
        //foreach (var ingredient in All)
        //{
        //    if (ingredient.Id == id)
        //    {
        //        return ingredient;
        //    }
        //}

        //return null;
    }
}

