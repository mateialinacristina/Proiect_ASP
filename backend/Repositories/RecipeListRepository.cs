using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public class RecipeListRepository : IRecipeListRepository
    {
        private ASP_projectContext db;
        public RecipeListRepository(ASP_projectContext db)
        {
            this.db = db;
        }


        public IQueryable<RecipeList> GetRecipeListIQueryable()
        {
            var recipeList = db.RecipeList;

            return recipeList;
        }

        public void Create(RecipeList recipeList)
        {
            db.RecipeList.Add(recipeList);

            db.SaveChanges();
        }

        public void Update(RecipeList recipeList)
        {
            db.RecipeList.Update(recipeList);

            db.SaveChanges();
        }

        public void Delete(RecipeList recipeList)
        {
            db.RecipeList.Remove(recipeList);

            db.SaveChanges();
        }
    }
}
