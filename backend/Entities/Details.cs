using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
    public class Details
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public string RecipeId { get; set; }  //FK
        public Recipe Recipe { get; set; }
    }
}
