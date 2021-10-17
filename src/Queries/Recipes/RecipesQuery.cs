using Kappelhoj.FoodPlanner.Core;
using Kappelhoj.FoodPlanner.Core.Contracts;
using Kappelhoj.FoodPlanner.Domain.Recipes;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kappelhoj.FoodPlanner.Queries.Recipes
{
    public class RecipesQuery : Query<Response<IEnumerable<RecipeViewModel>>>
    {
    }

    public class RecipesQueryHandler : IRequestHandler<RecipesQuery, Response<IEnumerable<RecipeViewModel>>>
    {
        private IEntityRetriever _entityRetriever;
        public RecipesQueryHandler(IEntityRetriever entityRetriever)
        {
            _entityRetriever = entityRetriever;
        }

        public async Task<Response<IEnumerable<RecipeViewModel>>> Handle(RecipesQuery request, CancellationToken cancellationToken)
        {
            var recipesQuery = await _entityRetriever.QueryEntities<Recipe>();

            var response = new Response<IEnumerable<RecipeViewModel>>
            {
                Result = recipesQuery.Select(r => r.MapToViewModel()).ToList()
            };

            return response;
        }
    }
}
