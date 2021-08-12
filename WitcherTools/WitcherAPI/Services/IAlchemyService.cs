using System.Collections.Generic;
using WitcherAPI.Models;
using WitcherAPI.Models.Alchemy;

namespace WitcherAPI.Services {
    public interface IAlchemyService {
        List<AlchemyProduct> GetAlchemyProducts();
        AlchemyProduct GetAlchemyProduct(string id);
    }
}