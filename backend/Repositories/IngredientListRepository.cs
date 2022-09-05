using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public class IngredientListRepository : IIngredientListRepository
    {
        private ASP_projectContext db;
        public IngredientListRepository(ASP_projectContext db)
        {
            this.db = db;
        }


        public IQueryable<IngredientList> GetIngredientListIQueryable()
        {
            var ingredientList = db.IngredientList;

            return ingredientList;
        }

        public void Create(IngredientList ingredientList)
        {
            db.IngredientList.Add(ingredientList);

            db.SaveChanges();
        }

        public void Update(IngredientList ingredientList)
        {
            db.IngredientList.Update(ingredientList);

            db.SaveChanges();
        }

        public void Delete(IngredientList ingredientList)
        {
            db.IngredientList.Remove(ingredientList);

            db.SaveChanges();
        }
    }
}
