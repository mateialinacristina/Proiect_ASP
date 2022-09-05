using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public interface IRecipeListManager
    {
        List<RecipeList> GetRecipeList();
        RecipeList GetRecipeListById(string id);
        void Create(RecipeList recipeList);
        void Update(RecipeList recipeList);
        void Delete(string id);
    }
}
