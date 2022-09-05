using ASP_project.Entities;
using ASP_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Managers
{
    public interface IDetailsManager
    {
        List<Details> GetDetails();
        Details GetDetailsByRecipeId(string recipeId);
        void Create(DetailsModel model);
        void Update(DetailsModel model);
        void Delete(string recipeId);
    }
}
