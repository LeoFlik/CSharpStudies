

namespace CookieRecipeBook.Recipe.IngredientsRepo;

    public interface IRecipeRepository
    {
        public List<Recipe> Read(string filePath);
        void Write(string filePath, List<Recipe> allRecipes);
    }
