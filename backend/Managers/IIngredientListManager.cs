using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public interface IIngredientListManager
    {
        List<IngredientList> GetIngredientList();
        IngredientList GetIngredientListById(string id);
        void Create(IngredientList ingredientList);
        void Update(IngredientList ingredientList);
        void Delete(string id);
    }
}
