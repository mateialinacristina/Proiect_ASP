using ASP_project.Managers;
using ASP_project.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsManager manager;
        public DetailsController(IDetailsManager detailsManager)
        {
            this.manager = detailsManager;
        }


        [HttpGet]
        [Authorize(Policy = "BasicUser")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetDetails()
        {

            var details = manager.GetDetails();

            return Ok(details);
        }




        [HttpPost("create-a-detail")]
        public async Task<IActionResult> Create([FromBody] DetailsModel detailsModel)
        {
            manager.Create(detailsModel);

            return Ok();
        }


        [HttpPut("update-a-detail")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] DetailsModel detailsModel)
        {
            manager.Update(detailsModel);

            return Ok();
        }

        [HttpDelete("delete-by-recipe-id{recipeId}")]
        public async Task<IActionResult> Delete([FromRoute] string recipeId)
        {
            manager.Delete(recipeId);

            return Ok();
        }
    }
}
