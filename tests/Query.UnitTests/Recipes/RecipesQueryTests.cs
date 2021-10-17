using AutoFixture;
using FoodPlanner.Application.Core.Contracts.Infrastructure;
using FoodPlanner.Domain.Recipes;
using FoodPlanner.Queries.Recipes;
using FoodPlanner.Queries.ViewModels;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FoodPlanner.Query.UnitTests.Recipes
{
    public class RecipesQueryTests
    {
        private Fixture _fixture = new Fixture();

        private Mock<IEntityRetriever> _entityRetrieverMock;
        private RecipesQueryHandler _recipesQueryHandler;


        public RecipesQueryTests() {
            _entityRetrieverMock = new Mock<IEntityRetriever>();

            _recipesQueryHandler = new RecipesQueryHandler(_entityRetrieverMock.Object);
        }

        [Fact]
        public async void GivenPersistedRecipes_WhenQueryRecipes_ThenSameRecipesReturned() 
        {
            //Arrange
            var recipesQuery = new RecipesQuery();
            var recipes = _fixture.CreateMany<Recipe>();

            _entityRetrieverMock.Setup(mock => mock.QueryEntities<Recipe>())
                .Returns(Task.FromResult(recipes.AsQueryable()));

            //Act
            var response = await _recipesQueryHandler.Handle(recipesQuery, CancellationToken.None);

            //Assert
            foreach (var recipe in recipes) {
                Assert.NotNull(response.Result.FirstOrDefault(x => x.Id == recipe.Id));
            }
        }
    }
}
