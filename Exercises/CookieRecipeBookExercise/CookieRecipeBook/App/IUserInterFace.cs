

namespace CookieRecipeBook.App;
public interface IUserInterFace
{
    public void ShowMessage(string message);
    public void Exit();
    public void PrintExistentRecipes(IEnumerable<Recipe> allRecipes);
    public void ShowAvaliableIngredients();
    public IEnumerable<Ingredient> GetIngredientsFromUser();

}
