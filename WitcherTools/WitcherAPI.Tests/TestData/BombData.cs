using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Bombs;

namespace WitcherAPI.Tests.TestData
{
    public class BombData
    {
        public static Bomb CreateBomb() {
            return new() {
                Id = "0003",
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
