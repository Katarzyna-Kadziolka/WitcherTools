using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WitcherAPI.Controllers;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Services;
using WitcherAPI.Tests.Extensions;
using WitcherAPI.Tests.TestData;

namespace WitcherAPI.Tests {
    public class AlchemyControllerTests {
        [Test]
        public void GetAlchemyProducts_NoQueryStringsParameters_ShouldReturnList() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> { PotionData.CreatePotion() };
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(expectedList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new AlchemyProductType[] { }, new Ingredients());
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }
    }
}