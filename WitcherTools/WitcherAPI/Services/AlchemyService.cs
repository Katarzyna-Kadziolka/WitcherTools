using System.Collections.Generic;
using WitcherAPI.Data;
using WitcherAPI.Models.Alchemy;

namespace WitcherAPI.Services {
    public class AlchemyService : IAlchemyService {
        private readonly DbClient _dbClient;

        public AlchemyService(DbClient dbClient) {
            _dbClient = dbClient;
        }

        public IEnumerable<AlchemyProduct> GetAlchemyProducts() =>
            _dbClient.GetAlchemyProducts();

        public AlchemyProduct GetAlchemyProduct(string id) => _dbClient.GetAlchemyProduct(id);
    }
}