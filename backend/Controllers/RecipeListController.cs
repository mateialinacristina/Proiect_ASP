using ASP_project.Entities;
using ASP_project.Managers;
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
    public class RecipeListController : ControllerBase
    {
        private readonly IRecipeListManager manager;
        public RecipeListController(IRecipeListManager recipeListManager)
        {
            this.manager = recipeListManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetRecipeList()
        {

            var recipeList = manager.GetRecipeList();

            return Ok(recipeList);
        }




        [HttpPost("create-a-recipe-list")]
        public async Task<IActionResult> Create([FromBody] RecipeList recipeList)
        {
            manager.Create(recipeList);

            return Ok();
        }

        [HttpPut("update-a-recipe-list")]
        public async Task<IActionResult> Update([FromBody] RecipeList recipeList)
        {
            manager.Update(recipeList);

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
