using System;
using System.Collections.Generic;
using WitcherAPI.Models;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Bombs;
using WitcherAPI.Models.Alchemy.Potions;

namespace WitcherAPI.Services {
    public class AlchemyServices : IAlchemyServices {
        public List<AlchemyProduct> GetAlchemyProducts() {
            return new List<AlchemyProduct> {
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
                },
                new Bomb() {
                    Id = "0002",
                    Name = AlchemyProductName.BombDancingStar,
                    Type = AlchemyProductType.Bomb,
                    AlchemyBase = AlchemyBase.Nitrate,
                    Ingredients = new Ingredients {
                        Hydragenum = 2,
                        Vermillion = 1,
                        Aether = 0,
                        Rebis = 0,
                        Vitriol = 0,
                        Quebrith = 0
                    },
                    Description = "Test2"
                }
            };
        }

        public AlchemyProduct GetAlchemyProduct(string id) {
            var list = new List<AlchemyProduct> {
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
                },
                new Bomb() {
                    Id = "0002",
                    Name = AlchemyProductName.BombDancingStar,
                    Type = AlchemyProductType.Bomb,
                    AlchemyBase = AlchemyBase.Nitrate,
                    Ingredients = new Ingredients {
                        Hydragenum = 2,
                        Vermillion = 1,
                        Aether = 0,
                        Rebis = 0,
                        Vitriol = 0,
                        Quebrith = 0
                    },
                    Description = "Test2"
                }
            };

            return list.Find(a => a.Id == id);
        }
    }
}

