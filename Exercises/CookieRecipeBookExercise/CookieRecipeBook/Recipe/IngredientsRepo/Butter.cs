namespace CookieRecipeBook.Recipe.IngredientsRepo;

    public class Butter : Ingredient
    {
    public override int Id => 8;
    public override string Name => "Butter";
    public override string PreparationInstructions => 
     $"Mealt it in low heat.{base.PreparationInstructions}";
}
