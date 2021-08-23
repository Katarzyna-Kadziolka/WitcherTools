using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Potions;

namespace WitcherAPI.Tests.TestData {
    public class PotionData {
        public static Potion CreatePotion() {
            return new() {
                Id = "6117e3a51c7e716eac97a554",
                Name = "Cat",
                Type = AlchemyProductType.Potion,
                AlchemyBase = AlchemyBase.Alcohol,
                Ingredients = new Ingredients {
                    Rebis = 2,
                    Aether = 1,
                    Vitriol = 0,
                    Vermilion = 0,
                    Quebrith = 0,
                    Hydragenum = 0
                },
                Description = "Test1",
                Duration = Duration.WholeDay
            };
        }
    }
}