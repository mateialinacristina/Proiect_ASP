using ASP_project.Entities;
using ASP_project.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientListController : ControllerBase
    {
        private readonly IIngredientListManager manager;
        public IngredientListController(IIngredientListManager ingredientListManager)
        {
            this.manager = ingredientListManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetIngredientList()
        {

            var ingredientList = manager.GetIngredientList();

            return Ok(ingredientList);
        }




        [HttpPost("create-ingredient-list")]
        public async Task<IActionResult> Create([FromBody] IngredientList ingredientList)
        {
            manager.Create(ingredientList);

            return Ok();
        }

        [HttpPut("update-ingredient-list")]
        public async Task<IActionResult> Update([FromBody] IngredientList ingredientList)
        {
            manager.Update(ingredientList);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            manager.Delete(id);

            return Ok();
        }



        /*

                [HttpGet("join-eager")]

                public async Task<IActionResult> JoinIngredientsToList()
                {
                    var listOfIngredients = manager.

                    var db = new ASP_projectContext();

                    var ingredientList = db.IngredientList
                        .Include(x => x.Ingredients)
                        .ToList();

                    foreach (var ingredient in ingredientList)
                    {
                        var ingredients = ingredient.Ingredients;
                    }

                    return Ok();
                }*/
    }
}
