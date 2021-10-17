using Kappelhoj.FoodPlanner.Domain.Recipes;

namespace Kappelhoj.FoodPlanner.Queries.Recipes
{
    public static class RecipeExtenstions
    {

        public static RecipeViewModel MapToViewModel(this Recipe recipe)
        {
            return new RecipeViewModel()
            {
                Id = recipe.Id
            };
        }
    }
}
