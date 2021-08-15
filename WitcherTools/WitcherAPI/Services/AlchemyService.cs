using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WitcherAPI.Data;
using WitcherAPI.Models;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Bombs;
using WitcherAPI.Models.Alchemy.Potions;

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