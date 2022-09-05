using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public interface IIngredientListRepository
    {
        IQueryable<IngredientList> GetIngredientListIQueryable();
        void Create(IngredientList ingredientList);
        void Update(IngredientList ingredientList);
        void Delete(IngredientList ingredientList);
    }
}
