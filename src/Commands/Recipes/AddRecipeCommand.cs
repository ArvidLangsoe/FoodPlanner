using FoodPlanner.Application.Core.Contracts.Infrastructure;
using FoodPlanner.Domain.Recipes;
using Kappelhoj.FoodPlanner.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Commands.Recipes
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
