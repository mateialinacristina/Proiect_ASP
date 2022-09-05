using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public class ShoppingListsRepository : IShoppingListsRepository
    {
        private ASP_projectContext db;
        public ShoppingListsRepository(ASP_projectContext db)
        {
            this.db = db;
        }

        public IQueryable<ShoppingList> GetShoppingListsIQueryable()
        {
            var shoppingList = db.ShoppingLists;

            return shoppingList;
        }

        public void Create(ShoppingList shoppingList)
        {
            db.ShoppingLists.Add(shoppingList);

            db.SaveChanges();
        }

        public void Update(ShoppingList shoppingList)
        {
            db.ShoppingLists.Update(shoppingList);

            db.SaveChanges();
        }

        public void Delete(ShoppingList shoppingList)
        {
            db.ShoppingLists.Remove(shoppingList);

            db.SaveChanges();
        }
    }
}
