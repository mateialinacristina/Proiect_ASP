using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class RecipeList
    {
        public string Id { get; set;}

        public ICollection<Recipe> Recipes { get; set; }
    }
}
