using System.Collections.Generic;
using WitcherAPI.Models;
using WitcherAPI.Models.Alchemy;

namespace WitcherAPI.Services {
    public interface IAlchemyServices {
        List<AlchemyProduct> GetAlchemyProducts();
    }
}