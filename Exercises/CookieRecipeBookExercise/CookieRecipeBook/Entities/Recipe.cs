using System.Linq;

namespace CookieRecipeBook.Entities;

public class Recipe
{
    public List<Ingredient> IngredientToAddToRecipe = [];

    public void AddToTheRecipe(Ingredient ingredient)=> IngredientToAddToRecipe.Add(ingredient);

    public void PrintRecipe()
    {
        // to add
    }

   
   
    





    

   
}
