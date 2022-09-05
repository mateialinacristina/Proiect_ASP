using ASP_project.Entities;
using ASP_project.Models;
using ASP_project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public class DetailsManager : IDetailsManager
    {
        private readonly IDetailsRepository detailsRepository;
        public DetailsManager(IDetailsRepository detailsRepository)
        {
            this.detailsRepository = detailsRepository;
        }
        public List<Details> GetDetails()
        {
            return detailsRepository.GetDetailsIQueryable().ToList();
        }

        public Details GetDetailsByRecipeId(string recipeId)
        {
            var details = detailsRepository.GetDetailsIQueryable()
                .FirstOrDefault(x => x.RecipeId == recipeId);

            return details;
        }
        public void Create(DetailsModel model)
        {
            var newDetails = new Details
            {
                Id = model.Id,
                Description = model.Description,
                RecipeId = model.RecipeId

            };

            detailsRepository.Create(newDetails);
        }

        public void Update(DetailsModel model)
        {
            var details = GetDetailsByRecipeId(model.RecipeId);

            details.Description = model.Description;
            details.RecipeId = model.RecipeId;

            detailsRepository.Update(details);
        }

        public void Delete(string recipeId)
        {
            var details = GetDetailsByRecipeId(recipeId);

            detailsRepository.Delete(details);
        }
    }
}
