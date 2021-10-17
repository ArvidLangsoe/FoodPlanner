using FoodPlanner.Application.Core.Contracts.Infrastructure;
using FoodPlanner.Domain.Recipes;
using FoodPlanner.Queries.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Queries.Recipes
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
