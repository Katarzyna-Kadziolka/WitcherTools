using System.Collections.Generic;
using WitcherAPI.Models;

namespace WitcherAPI.Services {
    interface IAlchemyServices {
        List<AlchemyProduct> GetAlchemyProducts();
    }
}