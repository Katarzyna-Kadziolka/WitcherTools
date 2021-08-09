using System.Net;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WitcherAPI.Controllers;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Services;

namespace WitcherAPI.Tests {
    public class AlchemyControllerTests {
        [Test]
        public void GetAlchemyProducts_NoQueryStringsParameters_ShouldReturnList() {
            // Arrange
            Mock<IAlchemyServices> moqAlchemyServices = new Mock<IAlchemyServices>();
            var controller = new AlchemyController(moqAlchemyServices.Object);
            //Act
            var result = controller.GetAlchemyProducts(null, new Ingredients());
            //Assert
            result.Result.Should().Be(HttpStatusCode.OK);
        }
    }
}