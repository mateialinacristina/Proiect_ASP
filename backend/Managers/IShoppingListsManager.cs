using ASP_project.Entities;
using ASP_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public interface IShoppingListsManager
    {
        List<ShoppingList> GetShoppingLists();
        ShoppingList GetShoppingListById(string id);
        void Create(ShoppingListModel model);
        void Update(ShoppingListModel model);
        void Delete(string id);
    }
}
