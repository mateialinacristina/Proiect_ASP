using ASP_project.Entities;
using ASP_project.Models;
using ASP_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public class ShoppingListsManager : IShoppingListsManager
    {
        private readonly IShoppingListsRepository shoppingListsRepository;
        public ShoppingListsManager(IShoppingListsRepository shoppingListsRepository)
        {
            this.shoppingListsRepository = shoppingListsRepository;
        }
        public List<ShoppingList> GetShoppingLists()
        {
            return shoppingListsRepository.GetShoppingListsIQueryable().ToList();
        }

        public ShoppingList GetShoppingListById(string id)
        {
            var shoppingList = shoppingListsRepository.GetShoppingListsIQueryable()
                .FirstOrDefault(x => x.Id == id);

            return shoppingList;
        }
        public void Create(ShoppingListModel model)
        {
            var newShoppingList = new ShoppingList
            {
                Id = model.Id,
                LimitDate = model.LimitDate
            };

            shoppingListsRepository.Create(newShoppingList);
        }

        public void Update(ShoppingListModel model)
        {
            var shoppingList = GetShoppingListById(model.Id);

            shoppingList.LimitDate = model.LimitDate;

            shoppingListsRepository.Update(shoppingList);
        }

        public void Delete(string id)
        {
            var shoppingList = GetShoppingListById(id);

            shoppingListsRepository.Delete(shoppingList);
        }
    }
}
