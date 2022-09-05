﻿using System;
using System.Collections.Generic;
using System.Linq;
using ASP_project.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ASP_project.Entities;
using ASP_project.Managers;



namespace ASP_project.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;

        public AuthenticationManager(UserManager<User> userManager, SignInManager<User> signInManager, ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }


        public async Task Signup(SignupUserModel signupUserModel)
        {
            var user = new User
            {
                Email = signupUserModel.Email,
                UserName = signupUserModel.Email
            };

            var result = await userManager.CreateAsync(user, signupUserModel.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, signupUserModel.RoleId);
            }
        }

        public async Task<TokenModel> Login(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);

            if (user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);
                if (result.Succeeded)
                {
                    var token = await tokenManager.CreateToken(user);

                    return new TokenModel { Token = token };
                }
            }

            return null;
        }
    }
}