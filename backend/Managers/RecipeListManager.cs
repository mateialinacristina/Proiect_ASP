using ASP_project.Entities;
using ASP_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public class RecipeListManager : IRecipeListManager
    {
        private readonly IRecipeListRepository recipeListRepository;
        public RecipeListManager(IRecipeListRepository recipeListRepository)
        {
            this.recipeListRepository = recipeListRepository;
        }
        public List<RecipeList> GetRecipeList()
        {
            return recipeListRepository.GetRecipeListIQueryable().ToList();
        }

        public RecipeList GetRecipeListById(string id)
        {
            var recipeList = recipeListRepository.GetRecipeListIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return recipeList;
        }
        public void Create(RecipeList recipeList)
        {
            recipeList.Id = recipeList.Id;

            recipeListRepository.Create(recipeList);
        }

        public void Update(RecipeList recipeList)
        {
            var recipe = GetRecipeListById(recipeList.Id);

            recipe.Id = recipeList.Id;

            recipeListRepository.Update(recipe);
        }

        public void Delete(string id)
        {
            var recipeList = GetRecipeListById(id);

            recipeListRepository.Delete(recipeList);
        }

    }
}
