using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Potions;

namespace WitcherAPI.Tests.TestData {
    public class PotionData {
        public static Potion CreatePotion() {
            return new Potion() {
                Id = "0001",
                Name = "Cat",
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
            };
        }
    }
}
// klasa dla oleju i dla bomby