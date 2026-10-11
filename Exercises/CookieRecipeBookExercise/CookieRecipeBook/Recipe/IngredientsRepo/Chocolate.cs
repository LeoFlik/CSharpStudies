namespace CookieRecipeBook.Recipe.IngredientsRepo;

public class Chocolate : Ingredient
{
    public override int Id => 5;
    public override string Name => "Chocolate";
    public override string PreparationInstructions =>
     $"Mealt in a water bath.{base.PreparationInstructions}";
}
