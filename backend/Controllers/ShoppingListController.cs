using ASP_project.Managers;
using ASP_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListsManager manager;
        public ShoppingListController(IShoppingListsManager shoppingListsManager)
        {
            this.manager = shoppingListsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingLists()
        {

            var shoppingLists = manager.GetShoppingLists();

            return Ok(shoppingLists);
        }

        [HttpPost("create-a-shopping-list")]
        public async Task<IActionResult> Create([FromBody] ShoppingListModel shoppingListModel)
        {
            manager.Create(shoppingListModel);

            return Ok();
        }

        [HttpPut("update-a-shopping-list")]
        public async Task<IActionResult> Update([FromBody] ShoppingListModel shoppingListModel)
        {
            manager.Update(shoppingListModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);

            return Ok();
        }
    }
}
