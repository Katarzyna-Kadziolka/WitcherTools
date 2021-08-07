namespace WitcherAPI.Models {
    public class AlchemyProduct {
        public AlchemyProductName Name { get; set; }
        public AlchemyProductType Type { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public AlchemyBase AlchemyBase { get; set; }
        public string Description { get; set; }
    }
}