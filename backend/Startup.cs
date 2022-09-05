using ASP_project.Controllers;
using ASP_project.Entities;
using ASP_project.Managers;
using ASP_project.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ASP_project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddCors(options =>       // PENTRU CORS
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });*/

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP_project", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddDbContext<ASP_projectContext>(options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ASP_project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true"));
            services.AddIdentity<User,Role>()
                .AddEntityFrameworkStores<ASP_projectContext>();

            services
               .AddAuthentication(options =>
               {

                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer("AuthScheme", options =>
               {
                   options.SaveToken = true;
                   var secret = Configuration.GetSection("Jwt").GetSection("SecretKey").Get<String>();
                   options.TokenValidationParameters = new TokenValidationParameters        // we verify if the token has been created using SecretKey
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       RequireExpirationTime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ClockSkew = TimeSpan.Zero
                   };
               });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("BasicUser", policy => policy.RequireRole("BasicUser").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IIngredientsRepository, IngredientsRepository>();//new instance of the service for each class that injects it
            /*  services.AddScoped<IIngredientsRepository, IngredientsRepository>(); //same instance of the service for the entire duration of the request
              services.AddSingleton<IIngredientsRepository, IngredientsRepository>(); // one single instance in the entire app

  */
            services.AddTransient<IIngredientsManager, IngredientsManager>();
            
            services.AddTransient<IRecipesRepository, RecipesRepository>();
            services.AddTransient<IRecipesManager, RecipesManager>();

            services.AddTransient<IDetailsRepository, DetailsRepository>();
            services.AddTransient<IDetailsManager, DetailsManager>();

            services.AddTransient<IShoppingListsRepository, ShoppingListsRepository>();
            services.AddTransient<IShoppingListsManager, ShoppingListsManager>();

            services.AddTransient<IRecipeListRepository, RecipeListRepository>();
            services.AddTransient<IRecipeListManager, RecipeListManager>();

            services.AddTransient<IIngredientListRepository, IngredientListRepository>();
            services.AddTransient<IIngredientListManager, IngredientListManager>();

            services.AddTransient<IAuthenticationManager, AuthenticationManager>();
            services.AddTransient<ITokenManager, TokenManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP_project v1"));
            }

            // app.UseCors("AllowOrigin");      PENTRU CORS

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
