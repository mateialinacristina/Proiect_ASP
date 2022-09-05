using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Repositories
{
    public class DetailsRepository : IDetailsRepository
    {
        private ASP_projectContext db;
        public DetailsRepository(ASP_projectContext db)
        {
            this.db = db;
        }


        public IQueryable<Details> GetDetailsIQueryable()
        {
            var details = db.Details;

            return details;
        }

        public void Create(Details details)
        {
            db.Details.Add(details);

            db.SaveChanges();
        }

        public void Update(Details details)
        {
            db.Details.Update(details);

            db.SaveChanges();
        }

        public void Delete(Details details)
        {
            db.Details.Remove(details);

            db.SaveChanges();
        }
    }
}
