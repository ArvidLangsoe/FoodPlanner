using Kappelhoj.FoodPlanner.Domain.Recipes;

namespace Kappelhoj.FoodPlanner.Queries.Recipes
{
    public static class RecipeExtenstions
    {
        public static RecipeViewModel MapToViewModel(this Recipe recipe) => new()
        {
            Id = recipe.Id
        };
    }
}
