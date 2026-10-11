using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieRecipeBook.FileAcess;
using CookieRecipeBook.Recipe.IngredientsRepo;

namespace CookieRecipeBook.Recipe.IngredientsRepo;

public class RecipeRepository : IRecipeRepository
{
    private readonly IStringRepository _stringRepository;
    private readonly IIngredientsMenu _ingredientsMenu;
    private const string Separator = ",";

    public RecipeRepository(IStringRepository stringRepository, IIngredientsMenu ingredientsMenu)
    {
        _stringRepository = stringRepository;
        _ingredientsMenu = ingredientsMenu;
    }
    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringRepository.Read(filePath);
        List<Recipe> recipeList = new List<Recipe>();
        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipeList.Add(recipe);
        }

        return recipeList;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();
        foreach (var textualId in textualIds)
        {
            int id = int.Parse(textualId);
            var ingredidentToAdd = _ingredientsMenu.GetById(id);
            if (ingredidentToAdd is null)
            {
                throw new InvalidOperationException($"No ingredient found with ID {id}.");
            }
            ingredients.Add(ingredidentToAdd);

        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.RecipeIngredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        _stringRepository.Write(filePath, recipesAsStrings);
    }
}
