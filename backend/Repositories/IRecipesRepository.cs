﻿using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public interface IRecipesRepository
    {
        IQueryable<Recipe> GetRecipesIQueryable();
        void Create(Recipe recipe);
        void Update(Recipe recipe);
        void Delete(Recipe recipe);
    }
}