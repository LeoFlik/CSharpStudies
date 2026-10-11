using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieRecipeBook.Recipe.IngredientsRepo;

   public interface IIngredientsMenu
{
   public IEnumerable<Ingredient> AllIngredients {get;}
   public Ingredient? GetById(int id);
}
