using CookieRecipeBook.Entities;
namespace CookieRecipeBook.Services
{
    public class UserInterFace
    {
        IngredientsMenu ingredientsMenu = new();


        public List<Ingredient> GetIngredientList()
        {
            ingredientsMenu.CreateAIngredient();
            return ingredientsMenu.Ingredients;
        }


        public void ShowAvaliableIngredients()
        {
            foreach (var item in GetIngredientList())
            {
                Console.WriteLine($"{item.Id}.{item.IngredientName}");
            }
        }

        public Ingredient GetUserInput()
        {
            Console.Write("Please insert the id of ingredient you want to add to the recipe:");
            int input;
            Ingredient ingredientToAdd;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 8)
            {
                Console.WriteLine("Invalid input, please insert a valid ingredient id. ");
            }
            ingredientToAdd = GetIngredientList().First(i => i.Id == input);
            Console.WriteLine(ShowIngridientAdded(ingredientToAdd));
            return ingredientToAdd;
        }

        public string ShowIngridientAdded(Ingredient ingredient) => $"{ingredient.IngredientName} had been add to the Recipe";
    }
}