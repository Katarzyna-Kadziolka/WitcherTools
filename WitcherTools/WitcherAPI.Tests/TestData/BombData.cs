using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Bombs;

namespace WitcherAPI.Tests.TestData {
    public class BombData {
        public static Bomb CreateBomb() {
            return new() {
                Id = "6117e3a51c7e716eac97a550",
                Name = "DancingStar",
                Type = AlchemyProductType.Bomb,
                AlchemyBase = AlchemyBase.Nitrate,
                Range = "5m",
                Description = "Test3",
                Ingredients = new Ingredients {
                    Aether = 0,
                    Hydragenum = 2,
                    Quebrith = 0,
                    Rebis = 0,
                    Vermillion = 2,
                    Vitriol = 0
                }
            };
        }
    }
}