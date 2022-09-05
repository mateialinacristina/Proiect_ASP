using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_project.Entities;
using Microsoft.AspNetCore.Identity;

namespace ASP_Project.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}