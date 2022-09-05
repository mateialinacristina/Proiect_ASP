using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class IngredientList
    {
        public string Id { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
