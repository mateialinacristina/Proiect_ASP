using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class IngredientShoppingList
    {
        public string IngredientId { get; set; }
        public string ShoppingListId { get; set; }
        

        public Ingredient Ingredient { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
