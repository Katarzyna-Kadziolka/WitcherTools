using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Oils;

namespace WitcherAPI.Tests.TestData {
    public class OilData {
        public static Oil CreateOil() {
            return new() {
                Id = "6117e3a51c7e716eac97a553",
                Name = "AgainstVampires",
                AlchemyBase = AlchemyBase.Saddle,
                Type = AlchemyProductType.Oil,
                OilEffectiveness = OilEffectiveness.Vampire,
                Description = "Test2",
                Ingredients = new Ingredients {
                    Aether = 2,
                    Hydragenum = 1,
                    Quebrith = 1,
                    Rebis = 0,
                    Vermillion = 0,
                    Vitriol = 0
                }
            };
        }
    }
}