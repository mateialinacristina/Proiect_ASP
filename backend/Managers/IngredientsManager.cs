using ASP_project.Entities;
using ASP_project.Models;
using ASP_project.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public class IngredientsManager : IIngredientsManager
    {
        private readonly IIngredientsRepository ingredientsRepository;
        public IngredientsManager(IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }
        public List<Ingredient> GetIngredients()
        {
            return ingredientsRepository.GetIngredientsIQueryable().ToList();
        }

        public List<string> GetIngredientsIdsList()
        {
            var ingredients = ingredientsRepository.GetIngredientsIQueryable();
            var idList = ingredients.Select(x => x.Id)
                .ToList();

            return idList;
        }

        public Ingredient GetIngredientById(string id)
        {
            var ingredient = ingredientsRepository.GetIngredientsIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return ingredient;
        }

        public List<Ingredient> GetIngredientsFiltered()
        {
            var ingredients = ingredientsRepository.GetIngredientsIQueryable()
                .Include(x => x.IngredientRecipes)
                .Where(x => x.IngredientRecipes.Count > 0)
                .OrderBy(x => x.Name)
                .ToList();
            return ingredients;
        }

        public void Create(string name)
        {
            var newIngredient = new Ingredient
            {
                Id = "10",
                Name = name,
                IngredientListId = "01"
            };

            ingredientsRepository.Create(newIngredient);
        }

        public void Create(IngredientModel model)
        {
            var newIngredient = new Ingredient
            {
                Id = model.Id,
                Name = model.Name,
                IngredientListId = "01" 
                //IngredientListId = model.IngredientListId
            };

            ingredientsRepository.Create(newIngredient);
        }

        public void Update(IngredientModel model) 
        {
            var ingredient = GetIngredientById(model.Id);

            ingredient.Name = model.Name;
            //ingredient.IngredientListId = model.IngredientListId;
            ingredientsRepository.Update(ingredient);
        }

        public void Delete(string id)
        {
            var ingredient = GetIngredientById(id);

            ingredientsRepository.Delete(ingredient);
        }

    }
}
