using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class IngredientRecipe
    {
        public string IngredientId { get; set; }
        public string RecipeId { get; set; }

        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
