using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public class RecipesRepository : IRecipesRepository
    { 
        private ASP_projectContext db;
        public RecipesRepository(ASP_projectContext db)
        {
            this.db = db;
        }


        public IQueryable<Recipe> GetRecipesIQueryable()
        {
            var recipes = db.Recipes;

            return recipes;
        }

        public void Create(Recipe recipe)
        {
            db.Recipes.Add(recipe);

            db.SaveChanges();
        }

        public void Update(Recipe recipe)
        {
            db.Recipes.Update(recipe);

            db.SaveChanges();
        }

        public void Delete(Recipe recipe)
        {
            db.Recipes.Remove(recipe);

            db.SaveChanges();
        }
    }
}
