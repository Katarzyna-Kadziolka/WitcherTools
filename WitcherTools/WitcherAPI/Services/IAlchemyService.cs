using System.Collections.Generic;
using WitcherAPI.Models;
using WitcherAPI.Models.Alchemy;

namespace WitcherAPI.Services {
    public interface IAlchemyService {
        IEnumerable<AlchemyProduct> GetAlchemyProducts();
        AlchemyProduct GetAlchemyProduct(string id);
    }
}