using ASP_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_project.Entities
{
  public class Brand
  {
    public string Id { get; set; }
    public string Name { get; set; }

    public string IngredientId { get; set; }  //FK
    public Ingredient Ingredient { get; set; }
  }
}
