using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public interface IIngredientsRepository
    {
        IQueryable<Ingredient> GetIngredientsIQueryable();
        void Create(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(Ingredient ingredient);
    }
}
