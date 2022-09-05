using ASP_project.Entities;
using ASP_project.Managers;
using ASP_project.Models;
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
    public class IngredientController : ControllerBase
    {

        private readonly IIngredientsManager manager;
        public IngredientController(IIngredientsManager ingredientsManager)
        {
            this.manager = ingredientsManager;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
     
            var ingredients = manager.GetIngredients(); 

            return Ok(ingredients);
        }
 
        //eager-loading
        [HttpGet("select-ids")]
        public async Task<IActionResult> GetIds()
        {
            var idList = manager.GetIngredientsIdsList();



            return Ok(idList);
        }

        //just ingredients used in recipes, ordered by name
        [HttpGet("filtered-ingredients-used-ordered")]
        public async Task<IActionResult> Filtered()
        {
            var filteredIngredients = manager.GetIngredientsFiltered();
            /*var db = new ASP_projectContext();
            var filteredIngredients = db.Ingredients
                .Include(x => x.IngredientRecipes)
                .Where(x => x.IngredientRecipes.Count > 0)
                .OrderBy(x => x.Name)
                .ToList();
            */
            return Ok(filteredIngredients);
        }
  
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            manager.Create(name);
            
            return Ok();
        }

        [HttpPost("with-ingredient-obj")]
        public async Task<IActionResult> Create([FromBody] IngredientModel ingredientModel)
        {
            manager.Create(ingredientModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] IngredientModel ingredientModel)
        {
            manager.Update(ingredientModel);

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
