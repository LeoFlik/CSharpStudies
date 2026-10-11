using CookieRecipeBook.Recipe.IngredientsRepo;

namespace CookieRecipeBook.Recipe.IngredientsRepo;



public class IngredientsMenu : IIngredientsMenu
{
   

    public IEnumerable<Ingredient> AllIngredients { get; } = new List<Ingredient>
    {
        new WheatFloor(),
        new CoconutFlour(),
        new CocoaPowder(),
        new Chocolate(),
        new Cinamom(),
        new Cardamom(),
        new Sugar(),
        new Butter()

    };

    public Ingredient? GetById(int id)
    {
        foreach (var ingredient in AllIngredients)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }
        }
        return null;

    }
}
