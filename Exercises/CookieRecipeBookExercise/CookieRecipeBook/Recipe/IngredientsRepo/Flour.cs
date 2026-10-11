using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieRecipeBook.Recipe.IngredientsRepo
{
    public abstract class Flour : Ingredient
    {
        public override string PreparationInstructions => $"Sieve.{base.PreparationInstructions}";
    }
}