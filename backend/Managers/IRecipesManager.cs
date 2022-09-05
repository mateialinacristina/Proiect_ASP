using ASP_project.Entities;
using ASP_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public interface IRecipesManager
    {
        List<Recipe> GetRecipes();
        Recipe GetRecipeById(string id);
        void Create(RecipeModel model);
        void Update(RecipeModel model);
        void Delete(string id);
    }
}
