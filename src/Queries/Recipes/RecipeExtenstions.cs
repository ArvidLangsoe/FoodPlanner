using FoodPlanner.Domain.Recipes;
using FoodPlanner.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Queries.Recipes
{
    public static class RecipeExtenstions
    {

        public static RecipeViewModel MapToViewModel(this Recipe recipe) 
        {
            return new RecipeViewModel() { 
                Id = recipe.Id 
            };
        }
    }
}
