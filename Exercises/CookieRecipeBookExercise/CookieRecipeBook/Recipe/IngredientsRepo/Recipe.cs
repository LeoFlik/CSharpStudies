using System.Linq;

namespace CookieRecipeBook.Recipe.IngredientsRepo;

public class Recipe
{
    public IEnumerable<Ingredient> RecipeIngredients;

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        RecipeIngredients = ingredients;
    }

    public override string ToString()
    {
        var descriptions = new List<String>();
        foreach (var ingredient in RecipeIngredients)
        {
            descriptions.Add($"{ingredient.Name}.{ingredient.PreparationInstructions}");
        }
        return string.Join(Environment.NewLine,descriptions);
    }
  
    }













