using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class ShoppingList
    {
        public string Id { get; set; }
        public string LimitDate { get; set; }

        public ICollection<IngredientShoppingList> IngredientShoppingLists { get; set; }
    }
}
