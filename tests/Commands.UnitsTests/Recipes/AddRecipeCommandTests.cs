using Kappelhoj.FoodPlanner.Commands.Recipes;
using Kappelhoj.FoodPlanner.Core.Contracts;
using Kappelhoj.FoodPlanner.Domain.Recipes;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kappelhoj.FoodPlanner.Commands.UnitTests.Recipes
{
    public class AddRecipeCommandTests
    {

        private AddRecipeHandler _addRecipeHandler;
        private Mock<IEntityPersister> _entityPersisterMock;

        public AddRecipeCommandTests()
        {

            _entityPersisterMock = new Mock<IEntityPersister>();
            _entityPersisterMock.Setup(mock => mock.PersistEntity(It.IsAny<Recipe>())).Returns<Recipe>(x => Task.FromResult(x));
            _addRecipeHandler = new AddRecipeHandler(_entityPersisterMock.Object);
        }


        [Fact]
        public async void GivenValidRecipe_WhenAddingRecipe_ThenRecipeIdReturned()
        {
            //Arrange
            var addRecipeCommand = CreateValidAddRecipeCommand();

            //Act
            var response = await _addRecipeHandler.Handle(addRecipeCommand, CancellationToken.None);

            //Assert
            Assert.NotEqual(Guid.Empty, response.Result);
        }

        [Fact]
        public async void GivenValidRecipe_WhenAddingRecipe_ThenRecipeEntityAdded()
        {
            //Arrange
            var addRecipeCommand = CreateValidAddRecipeCommand();
            Recipe? entityCreated = null;

            _entityPersisterMock.Setup(mock => mock.PersistEntity(It.IsAny<Recipe>()))
                .Callback<Recipe>(x => entityCreated = x)
                .Returns<Recipe>(x => Task.FromResult(x));

            //Act
            var response = await _addRecipeHandler.Handle(addRecipeCommand, CancellationToken.None);

            //Assert
            _entityPersisterMock.Verify(mock => mock.PersistEntity(It.IsAny<Recipe>()), Times.Once);
            Assert.NotNull(entityCreated?.Id);
            Assert.Equal(response.Result, entityCreated?.Id);
            Assert.Equal(addRecipeCommand.Title, entityCreated?.Title);
        }



        private AddRecipeCommand CreateValidAddRecipeCommand()
        {
            return new AddRecipeCommand() { Title = "Meatballs" }; //TODO: Autofixture??
        }
    }
}
