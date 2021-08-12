using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WitcherAPI.Controllers;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Potions;
using WitcherAPI.Services;

namespace WitcherAPI.Tests {
    public class AlchemyControllerTests {
        [Test]
        public void GetAlchemyProducts_NoQueryStringsParameters_ShouldReturnList() {
            // Arrange
            Mock<IAlchemyServices> moqAlchemyServices = new Mock<IAlchemyServices>();
            var exampleList = new List<AlchemyProduct> {
                new Potion() {
                    Id = "0001",
                    Name = AlchemyProductName.PotionCat,
                    Type = AlchemyProductType.Potion,
                    AlchemyBase = AlchemyBase.Alcohol,
                    Ingredients = new Ingredients {
                        Rebis = 2,
                        Aether = 1,
                        Vitriol = 0,
                        Vermillion = 0,
                        Quebrith = 0,
                        Hydragenum = 0
                    },
                    Description = "Test1"
                }
            };
            moqAlchemyServices.Setup(a => a.GetAlchemyProducts()).Returns(exampleList);
            var controller = new AlchemyController(moqAlchemyServices.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new AlchemyProductType[]{}, new Ingredients());
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<AlchemyProduct>;
            //Assert
            result.Should().BeOfType<OkObjectResult>();
            actual.Should().BeEquivalentTo(exampleList);
        }
    }
}