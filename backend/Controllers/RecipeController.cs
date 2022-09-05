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
    public class RecipeController : ControllerBase
    {
        private readonly IRecipesManager manager;
        public RecipeController(IRecipesManager recipesManager)
        {
            this.manager = recipesManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {

            var recipes = manager.GetRecipes();

            return Ok(recipes);
        }

        


        [HttpPost("create-a-recipe")]
        public async Task<IActionResult> Create([FromBody] RecipeModel recipeModel)
        {
            manager.Create(recipeModel);

            return Ok();
        }

        [HttpPut("update-a-recipe")]
        public async Task<IActionResult> Update([FromBody] RecipeModel recipeModel)
        {
            manager.Update(recipeModel);

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
