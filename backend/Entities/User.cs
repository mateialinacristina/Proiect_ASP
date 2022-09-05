using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Project.Entities;
using Microsoft.AspNetCore.Identity;

namespace ASP_project.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
