
namespace CookieRecipeBook.App;

    public class UserInterFace : IUserInterFace
    {
        private readonly IngredientsMenu _ingredientsMenu;

        public UserInterFace(IngredientsMenu ingredientsMenu)
        {
            _ingredientsMenu = ingredientsMenu;
        }

        public void ShowAvaliableIngredients()
        {
            Console.WriteLine("Create a new cookie recipre! The avaliabe ingredients are:");
            foreach (var item in _ingredientsMenu.AllIngredients)
            {
                Console.WriteLine(item.ToString());
            }

        }

        public void PrintExistentRecipes(IEnumerable<Recipe> allRecipes)
        {
            if (allRecipes.Count() > 0)
            {
                Console.WriteLine("These are the avaliable recipes:" + Environment.NewLine);
                var recipeIndex = 1;
                foreach (var recipe in allRecipes)
                {
                    Console.WriteLine($"*********{recipeIndex}**********");
                    Console.WriteLine(recipe);
                    Console.WriteLine();
                    ++recipeIndex;

                }
            }
        }


        public void ShowMessage(string message)
        {
           Console.WriteLine(message);
        }

        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public IEnumerable<Ingredient> GetIngredientsFromUser()
        {
            bool stopIteration = false;
            var listOfIngredients = new List<Ingredient>();
            while (!stopIteration)
            {
                Console.WriteLine("Add an ingredient by Id or press anything else to exit the application");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int id))
                {
                    var selectedById = _ingredientsMenu.GetById(id);
                    if (selectedById is not null)
                    {
                        listOfIngredients.Add(selectedById);
                    }

                }
                else
                {
                    stopIteration = true;
                }

            }


            return listOfIngredients;
        }
    }
