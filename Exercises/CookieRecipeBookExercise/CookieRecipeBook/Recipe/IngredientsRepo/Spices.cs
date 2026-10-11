using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieRecipeBook.Recipe.IngredientsRepo
{
    public abstract class Spices : Ingredient
    {
        public override string PreparationInstructions =>$" Take a half of tea spoon.{base.PreparationInstructions}";
    }
}