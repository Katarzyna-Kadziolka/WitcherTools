using System;
using System.Collections.Generic;
using WitcherAPI.Models;

namespace WitcherAPI.Services {
    public class AlchemyServices : IAlchemyServices {
        public List<AlchemyProduct> GetAlchemyProducts() {
            return new List<AlchemyProduct> {
                new AlchemyProduct {
                    Id = "0001",
                    Name = AlchemyProductName.PotionCat,
                    Type = AlchemyProductType.Potion,
                    AlchemyBase = AlchemyBase.Alcohol,
                    Ingredients = new Ingredient[2] {
                        new Ingredient {
                            Name = IngredientName.Aether,
                            Amount = 2
                        },
                        new Ingredient {
                            Name = IngredientName.Rebis,
                            Amount = 3
                        }
                    },
                    Description = "Test1"
                },
                new AlchemyProduct {
                    Id = "0002",
                    Name = AlchemyProductName.BombDancingStar,
                    Type = AlchemyProductType.Bomb,
                    AlchemyBase = AlchemyBase.Nitrate,
                    Ingredients = new Ingredient[2] {
                        new Ingredient {
                            Name = IngredientName.Hydragenum,
                            Amount = 2
                        },
                        new Ingredient {
                            Name = IngredientName.Vermillion,
                            Amount = 3
                        }
                    },
                    Description = "Test2"
                }
            };
        }
    }
}