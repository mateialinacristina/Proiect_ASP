using ASP_project.Entities;
using ASP_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public class IngredientListManager  : IIngredientListManager
    {
        private readonly IIngredientListRepository ingredientListRepository;
        public IngredientListManager(IIngredientListRepository ingredientListRepository)
        {
            this.ingredientListRepository = ingredientListRepository;
        }
        public List<IngredientList> GetIngredientList()
        {
            return ingredientListRepository.GetIngredientListIQueryable().ToList();
        }

        public IngredientList GetIngredientListById(string id)
        {
            var ingredientList = ingredientListRepository.GetIngredientListIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return ingredientList;
        }
        public void Create(IngredientList ingredientList)
        {
            ingredientList.Id = ingredientList.Id;

            ingredientListRepository.Create(ingredientList);
        }

        public void Update(IngredientList ingredientList)
        {
            var ingredient = GetIngredientListById(ingredientList.Id);

            ingredient.Id = ingredientList.Id;

            ingredientListRepository.Update(ingredient);
        }

        public void Delete(string id)
        {
            var ingredientList = GetIngredientListById(id);

            ingredientListRepository.Delete(ingredientList);
        }

    }
}
