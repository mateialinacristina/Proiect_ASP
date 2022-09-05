using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_project.Entities;


namespace ASP_project.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}
