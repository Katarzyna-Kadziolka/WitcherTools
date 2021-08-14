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
        public void GetAlchemyProducts_NoQueryStringsParameters_ShouldReturnListWithThreeElements() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new AlchemyProductType[] { }, new Ingredients());
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypePotion_ShouldReturnListWithOneElement() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> {PotionData.CreatePotion()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new[] {AlchemyProductType.Potion}, new Ingredients());
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypeOil_ShouldReturnListWithOneElement() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> {OilData.CreateOil()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new[] {AlchemyProductType.Oil}, new Ingredients());
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypeBomb_ShouldReturnListWithOneElement() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> {BombData.CreateBomb()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new[] {AlchemyProductType.Bomb}, new Ingredients());
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypePotionAndOil_ShouldReturnListWithTwoElements() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> {PotionData.CreatePotion(), OilData.CreateOil()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new[] {AlchemyProductType.Potion, AlchemyProductType.Oil},
                new Ingredients());
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypePotionAndOilAndBomb_ShouldReturnListWithThreeElements() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(
                new[] {AlchemyProductType.Potion, AlchemyProductType.Oil, AlchemyProductType.Bomb},
                new Ingredients());
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_AllIngredientsAreGiven_ShouldReturnListWithOneElement() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> {PotionData.CreatePotion()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new AlchemyProductType[] { },
                new Ingredients {Aether = 1, Rebis = 2, Hydragenum = 1, Quebrith = 1, Vermillion = 1, Vitriol = 1});
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_SameIngredientsAreNulls_ShouldReturnListWithOneElement() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> {PotionData.CreatePotion()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new AlchemyProductType[] { },
                new Ingredients {Aether = 1, Rebis = 2});
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_OneIngredientIsEnoughSecondIngredientIsTooLess_ShouldReturnEmptyListt() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> { };
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new AlchemyProductType[] { },
                new Ingredients {Aether = 1, Rebis = 1, Hydragenum = 1, Quebrith = 1, Vermillion = 1, Vitriol = 1});
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypePotionAndEnoughIngredients_ShouldReturnListWithOneElement() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> {PotionData.CreatePotion()};
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new[] {AlchemyProductType.Potion},
                new Ingredients {Aether = 1, Rebis = 2, Hydragenum = 1, Quebrith = 1, Vermillion = 1, Vitriol = 1});
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypePotionAndTooLessIngredients_ShouldReturnEmptyList() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> { };
            var serviceList = new List<AlchemyProduct>
                {PotionData.CreatePotion(), OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new[] {AlchemyProductType.Potion},
                new Ingredients {Aether = 1, Rebis = 1, Hydragenum = 1, Quebrith = 1, Vermillion = 1, Vitriol = 1});
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProducts_TypePotionWitchIsNotOnTheListAndEnoughIngredients_ShouldReturnEmptyList() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedList = new List<AlchemyProduct> { };
            var serviceList = new List<AlchemyProduct>
                {OilData.CreateOil(), BombData.CreateBomb()};
            alchemyService.Setup(a => a.GetAlchemyProducts()).Returns(serviceList);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProducts(new[] {AlchemyProductType.Potion},
                new Ingredients {Aether = 1, Rebis = 1, Hydragenum = 2, Quebrith = 1, Vermillion = 2, Vitriol = 1});
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedList);
        }

        [Test]
        public void GetAlchemyProduct_ExistingId_ShouldReturnAlchemyProduct() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var expectedAlchemyProduct = PotionData.CreatePotion();
            alchemyService.Setup(a => a.GetAlchemyProduct(expectedAlchemyProduct.Id)).Returns(expectedAlchemyProduct);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProduct("0001");
            //Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            actionResult.GetValue().Should().BeEquivalentTo(expectedAlchemyProduct);
        }
        [Test]
        public void GetAlchemyProduct_ExistingId_ShouldReturnNotFound() {
            // Arrange
            Mock<IAlchemyService> alchemyService = new Mock<IAlchemyService>();
            var alchemyProduct = PotionData.CreatePotion();
            alchemyService.Setup(a => a.GetAlchemyProduct(alchemyProduct.Id)).Returns(alchemyProduct);
            var controller = new AlchemyController(alchemyService.Object);
            //Act
            var actionResult = controller.GetAlchemyProduct("noId");
            //Assert
            actionResult.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}