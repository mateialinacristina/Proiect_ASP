using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_project.Models;

namespace ASP_project.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(SignupUserModel signupUserModel);
        Task<TokenModel> Login(LoginUserModel loginUserModel);
    }
}
