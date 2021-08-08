using System.Collections.Generic;
using WitcherAPI.Models;

namespace WitcherAPI.Services {
    public interface IAlchemyServices {
        List<AlchemyProduct> GetAlchemyProducts();
    }
}