using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ASP_Project.Entities;

namespace ASP_project.Entities
{
    // public class ASP_projectContext : DbContext
    public class ASP_projectContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>

    {
        public ASP_projectContext(DbContextOptions<ASP_projectContext> options) : base(options) { }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<RecipeList> RecipeList { get; set; }
        public DbSet<IngredientList> IngredientList { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<IngredientShoppingList> IngredientShoppingLists { get; set; }
       
        public DbSet<ShoppingList> Brand { get; set; }
  /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            //.UseLazyLoadingProxies()
            .UseLoggerFactory(LoggerFactory.Create(DbContextOptionsBuilder => DbContextOptionsBuilder.AddConsole()))    // this line will print the result of the select into the console
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ASP_project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
    }
  */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //MANY TO MANY
            builder.Entity<IngredientRecipe>().HasKey(ir => new { ir.IngredientId, ir.RecipeId });

            builder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Ingredient)
                .WithMany(i => i.IngredientRecipes)
                .HasForeignKey(ir => ir.IngredientId);

            builder.Entity<IngredientRecipe>()
                .HasOne(ir => ir.Recipe)
                .WithMany(r => r.IngredientRecipes)
                .HasForeignKey(ir => ir.RecipeId);

            //ONE TO ONE
            builder.Entity<Recipe>()
                .HasOne(r => r.Details)
                .WithOne(d => d.Recipe);

            //ONE TO MANY
            builder.Entity<RecipeList>()
                .HasMany(rl => rl.Recipes)
                .WithOne(r => r.RecipeList);

            //ONE TO MANY
            builder.Entity<IngredientList>()
                 .HasMany(il => il.Ingredients)
                 .WithOne(i => i.IngredientList);

            //MANY TO MANY
            builder.Entity<IngredientShoppingList>().HasKey(isl => new { isl.IngredientId, isl.ShoppingListId });

            builder.Entity<IngredientShoppingList>()
                .HasOne(isl => isl.Ingredient)
                .WithMany(i => i.IngredientShoppingLists)
                .HasForeignKey(isl => isl.IngredientId);

            builder.Entity<IngredientShoppingList>()
                .HasOne(isl => isl.ShoppingList)
                .WithMany(sl => sl.IngredientShoppingLists)
                .HasForeignKey(isl => isl.ShoppingListId);

            //ONE TO ONE
            builder.Entity<Ingredient>()
                .HasOne(i => i.Brand)
                .WithOne(b => b.Ingredient);

        }
    }
}
