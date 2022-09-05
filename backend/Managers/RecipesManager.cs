using ASP_project.Entities;
using ASP_project.Models;
using ASP_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public class RecipesManager : IRecipesManager
    {
        private readonly IRecipesRepository recipesRepository;
        public RecipesManager(IRecipesRepository recipesRepository)
        {
            this.recipesRepository = recipesRepository;
        }
        public List<Recipe> GetRecipes()
        {
            return recipesRepository.GetRecipesIQueryable().ToList();
        }

        public Recipe GetRecipeById(string id)
        {
            var recipe = recipesRepository.GetRecipesIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return recipe;
        }
        public void Create(RecipeModel model)
        {
            var newRecipe = new Recipe
            {
                Id = model.Id,
                Name = model.Name,
                RecipeListId = "20"
                
            };

            recipesRepository.Create(newRecipe);
        }

        public void Update(RecipeModel model)
        {
            var recipe = GetRecipeById(model.Id);

            recipe.Name = model.Name;
            
            recipesRepository.Update(recipe);
        }

        public void Delete(string id)
        {
            var recipe = GetRecipeById(id);

            recipesRepository.Delete(recipe);
        }

    }
}
