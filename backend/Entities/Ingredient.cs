using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }


        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }

        public string IngredientListId { get; set; } //FK
        public IngredientList IngredientList { get; set; }

        public ICollection<IngredientShoppingList> IngredientShoppingLists { get; set; }
    }
}
