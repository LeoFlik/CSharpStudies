using CookieRecipeBook.Entities.IngredientsRepo;

namespace CookieRecipeBook.Entities;

public class IngredientsMenu
{
    public List<Ingredient> Ingredients { get; set; } = [];

    public void AddIngredient(Ingredient ingredient) => Ingredients.Add(ingredient);
    public void RemoveIngredient(Ingredient ingredient) => Ingredients.Remove(ingredient);

    public void CreateAIngredient()
    {
        AddIngredient(new WheatFloor(1, "Wheat Flour", "Sieve, add to other ingredients."));
        AddIngredient(new CoconutFlour(2, "Coconut Flour", "Sieve, add to other ingredients."));
        AddIngredient(new CocoaPowder(3, "Cocoa Powder", "Sieve, add to other ingredients."));
        AddIngredient(new Chocolate(4, "Chocolate", "Melt in a water bath,add to another ingredient."));
        AddIngredient(new Sugar(5, "Sugar", "Add to other ingredients."));
        AddIngredient(new Cardamom(6, "Cardamom","Take  a half teaspoon, add to other ingredient."));
        AddIngredient(new Cinamom(7, "Cinnamom", "Take  a half teaspoon, add to other ingredient."));
        AddIngredient(new Butter(8, "Butter", "Mealt on low heat, add to other ingredients."));
    }
}
