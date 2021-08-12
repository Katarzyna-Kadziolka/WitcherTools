using MongoDB.Bson.Serialization.Attributes;

namespace WitcherAPI.Models.Alchemy {
    public abstract class AlchemyProduct {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public AlchemyProductName Name { get; set; }
        public AlchemyProductType Type { get; set; }
        public Ingredients Ingredients { get; set; }
        public AlchemyBase AlchemyBase { get; set; }
        public string Description { get; set; }
    }
}