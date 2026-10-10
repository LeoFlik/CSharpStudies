
namespace CookieRecipeBook.Entities;

public abstract class Ingredient
{
    public int Id { get; set; }
    public string? IngredientName { get; set; }
    public string? Preparation { get; set; }

    public Ingredient(int id,string name,string preparation)
    {
        Id = id;
        IngredientName = name;
        Preparation = preparation;
    }
}

