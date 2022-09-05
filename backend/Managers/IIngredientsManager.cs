using ASP_project.Entities;
using ASP_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public interface IIngredientsManager
    {
        List<Ingredient> GetIngredients();
        List<string> GetIngredientsIdsList();
        List<Ingredient> GetIngredientsFiltered(); //used in recipes
        Ingredient GetIngredientById(string id);
        void Create(string name);
        void Create(IngredientModel model);
        void Update(IngredientModel model);
        void Delete(string id);

    }
}
