using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public interface IRecipeListRepository
    {
        IQueryable<RecipeList> GetRecipeListIQueryable();
        void Create(RecipeList recipeList);
        void Update(RecipeList recipeList);
        void Delete(RecipeList recipeList);
    }
}
