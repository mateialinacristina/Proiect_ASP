using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class Recipe
    {
        public string Id { get; set; } 
        public string Name { get; set; }


        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
        public Details Details { get; set; }
        
        public string RecipeListId { get; set; } //FK
        public RecipeList RecipeList { get; set; }
    }
}
