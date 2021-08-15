using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using WitcherAPI.Controllers;
using WitcherAPI.Converters;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Bombs;
using WitcherAPI.Models.Alchemy.Oils;
using WitcherAPI.Models.Alchemy.Potions;
using WitcherAPI.Services;
using WitcherAPI.Tests.Extensions;
using WitcherAPI.Tests.TestData;

namespace WitcherAPI.Tests {
    public class BsonToAlchemyProductConverterTests {
        [Test]
        public void Convert_BsonContainsPotion_ShouldReturnPotion() {
            // Arrange
            var expectedResult = PotionData.CreatePotion();
            var bson = expectedResult.ToBsonDocument();
            //Act
            var alchemyProduct = BsonToAlchemyProductConverter.Convert(bson);
            //Assert
            alchemyProduct.Should().BeEquivalentTo(expectedResult);
            alchemyProduct.Should().BeOfType<Potion>();
        }
        [Test]
        public void Convert_BsonContainsOil_ShouldReturnOil() {
            // Arrange
            var expectedResult = OilData.CreateOil();
            var bson = expectedResult.ToBsonDocument();
            //Act
            var alchemyProduct = BsonToAlchemyProductConverter.Convert(bson);
            //Assert
            alchemyProduct.Should().BeEquivalentTo(expectedResult);
            alchemyProduct.Should().BeOfType<Oil>();
        }
        [Test]
        public void Convert_BsonContainsBomb_ShouldReturnBomb() {
            // Arrange
            var expectedResult = BombData.CreateBomb();
            var bson = expectedResult.ToBsonDocument();
            //Act
            var alchemyProduct = BsonToAlchemyProductConverter.Convert(bson);
            //Assert
            alchemyProduct.Should().BeEquivalentTo(expectedResult);
            alchemyProduct.Should().BeOfType<Bomb>();
        }
        [Test]
        public void Convert_BsonContainsTypeUnknown_ShouldReturnArgumentOutOfRangeException() {
            // Arrange
            var potion = PotionData.CreatePotion();
            potion.Type = AlchemyProductType.Unknown;
            var bson = potion.ToBsonDocument();
            //Act
            Action act = () => BsonToAlchemyProductConverter.Convert(bson);
            //Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
        [Test]
        public void Convert_IncorrectClass_ShouldReturn() {
            // Arrange
            var incorrectClass = new {
                Name = "test"
            };
            var bson = incorrectClass.ToBsonDocument();
            //Act
            Action act = () => BsonToAlchemyProductConverter.Convert(bson);
            //Assert
            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
