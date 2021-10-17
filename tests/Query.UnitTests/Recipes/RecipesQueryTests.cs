using AutoFixture;
using Kappelhoj.FoodPlanner.Core.Contracts;
using Kappelhoj.FoodPlanner.Domain.Recipes;
using Kappelhoj.FoodPlanner.Queries.Recipes;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kappelhoj.FoodPlanner.Queries.UnitTests.Recipes
{
    public class RecipesQueryTests
    {
        private readonly Fixture _fixture = new Fixture();

        private readonly Mock<IEntityRetriever> _entityRetrieverMock;
        private readonly RecipesQueryHandler _recipesQueryHandler;

        public RecipesQueryTests()
        {
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
            foreach (var recipe in recipes)
            {
                Assert.NotNull(response.Result.FirstOrDefault(x => x.Id == recipe.Id));
            }
        }
    }
}
