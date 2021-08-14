using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WitcherAPI.Models.Alchemy.Potions {
    public class Potion : AlchemyProduct {
        [BsonRepresentation(BsonType.Int32)]         // Mongo
        public Duration Duration { get; set; }
    }
}