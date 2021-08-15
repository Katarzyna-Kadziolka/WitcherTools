using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using WitcherAPI.Models.Alchemy;
using WitcherAPI.Models.Alchemy.Bombs;
using WitcherAPI.Models.Alchemy.Oils;
using WitcherAPI.Models.Alchemy.Potions;

namespace WitcherAPI.Converters {
    public class BsonToAlchemyProductConverter {
        public static AlchemyProduct Convert(BsonDocument bson) {
            var type = (AlchemyProductType) bson[nameof(AlchemyProduct.Type)].AsInt32;
            AlchemyProduct alchemyProduct;
            switch (type) {
                case AlchemyProductType.Potion:
                    alchemyProduct = BsonSerializer.Deserialize<Potion>(bson);
                    break;
                case AlchemyProductType.Oil:
                    alchemyProduct = BsonSerializer.Deserialize<Oil>(bson);
                    break;
                case AlchemyProductType.Bomb:
                    alchemyProduct = BsonSerializer.Deserialize<Bomb>(bson);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return alchemyProduct;

        }
    }
}