using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WitcherAPI.Converters;
using WitcherAPI.Models.Alchemy;

namespace WitcherAPI.Data {
    public class DbClient {
        private readonly DbConfig _dbConfig;
        private readonly IMongoDatabase _database;

        public DbClient(IOptions<DbConfig> dbConfig) {
            _dbConfig = dbConfig.Value;
            var client = new MongoClient(_dbConfig.Connection_String);
            _database = client.GetDatabase(_dbConfig.Database_Name);
        }

        public IEnumerable<AlchemyProduct> GetAlchemyProducts() {
            var rawData = _database.GetCollection<BsonDocument>(_dbConfig.Alchemy_Products_Collection_Name)
                .Find(a => true).ToList();
            var alchemyProducts = new List<AlchemyProduct>();
            foreach (var bson in rawData) {
                alchemyProducts.Add(BsonToAlchemyProductConverter.Convert(bson));
            }

            return alchemyProducts;
        }

        public AlchemyProduct GetAlchemyProduct(string id) {
            var rawData = _database.GetCollection<BsonDocument>(_dbConfig.Alchemy_Products_Collection_Name)
                .Find($"{{ _id: ObjectId('{id}') }}").Single();
            var alchemyProduct = BsonToAlchemyProductConverter.Convert(rawData);
            return alchemyProduct;
        }
    }
}