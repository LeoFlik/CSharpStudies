using System.Runtime.CompilerServices;
using CookieRecipeBook.FileAcess;
using CookieRecipeBook.Recipe.IngredientsRepo;
using CookieRecipeBook.DataAcess;


namespace CookieRecipeBook.App
{
    public class CookBookApp
    {
        private readonly IUserInterFace _userInterFace;
        private readonly IRecipeRepository _recipeRepository;
       
        private readonly object? filePath;

        public CookBookApp(IUserInterFace userInterFace,
         IRecipeRepository recipeRepository)
        {
            _userInterFace = userInterFace;
            _recipeRepository = recipeRepository;
           
        }

        public void Run(string filePath)
        {
            var allRecipes = _recipeRepository.Read(filePath);
            _userInterFace.PrintExistentRecipes(allRecipes);
            _userInterFace.ShowAvaliableIngredients();

            var ingredients = _userInterFace.GetIngredientsFromUser();
            if (ingredients.Count() > 0)
            {
                var recipes = new Recipe(ingredients);
                allRecipes.Add(recipes);
                _recipeRepository.Write(filePath,allRecipes);
                _userInterFace.ShowMessage("The recipe has been add:");
                _userInterFace.ShowMessage(recipes.ToString());
            }
            else
            {
                Console.WriteLine($"No ingredient has been added. The recipe will not be saved");
            }

            _userInterFace.Exit();
        }
    }


}