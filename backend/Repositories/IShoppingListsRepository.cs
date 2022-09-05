using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public interface IShoppingListsRepository
    {
        IQueryable<ShoppingList> GetShoppingListsIQueryable();
        void Create(ShoppingList shoppingList);
        void Update(ShoppingList shoppingList);
        void Delete(ShoppingList shoppingList);
    }
}
