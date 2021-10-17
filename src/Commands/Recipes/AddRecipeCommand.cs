using Kappelhoj.FoodPlanner.Core;
using Kappelhoj.FoodPlanner.Core.Contracts;
using Kappelhoj.FoodPlanner.Domain.Recipes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kappelhoj.FoodPlanner.Commands.Recipes
{
    public class AddRecipeCommand : Command<Response<Guid>>
    {
        public string Title { get; set; }

    }

    public class AddRecipeHandler : IRequestHandler<AddRecipeCommand, Response<Guid>>
    {
        private readonly IEntityPersister _entityPersister;

        public AddRecipeHandler(IEntityPersister repository)
        {
            _entityPersister = repository;
        }


        public async Task<Response<Guid>> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe()
            {
                Id = Guid.NewGuid(),
                Title = request.Title
            };

            await _entityPersister.PersistEntity(recipe);

            return new Response<Guid>
            {
                Result = recipe.Id
            };
        }
    }
}
