using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public interface IDetailsRepository
    {
        IQueryable<Details> GetDetailsIQueryable();
        void Create(Details details);
        void Update(Details details);
        void Delete(Details details);
    }
}
