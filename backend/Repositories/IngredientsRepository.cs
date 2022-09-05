using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private ASP_projectContext db;
        public IngredientsRepository(ASP_projectContext db)
        {
            this.db = db;
        }


        public IQueryable<Ingredient> GetIngredientsIQueryable()
        {
            var ingredients = db.Ingredients;

            return ingredients;
        }

        public void Create(Ingredient ingredient)
        {
            db.Ingredients.Add(ingredient);

            db.SaveChanges();
        }

        public void Update(Ingredient ingredient)
        {
            db.Ingredients.Update(ingredient);

            db.SaveChanges();
        }

        public void Delete(Ingredient ingredient)
        {
            db.Ingredients.Remove(ingredient);

            db.SaveChanges();
        }
    }
}
