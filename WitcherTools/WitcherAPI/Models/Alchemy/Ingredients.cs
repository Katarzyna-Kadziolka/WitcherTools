using System.Linq;

namespace WitcherAPI.Models.Alchemy {
    public class Ingredients {
        public int? Rebis { get; set; }
        public int? Vitriol { get; set; }
        public int? Aether { get; set; }
        public int? Quebrith { get; set; }
        public int? Hydragenum { get; set; }
        public int? Vermillion { get; set; }

        public bool Contains(Ingredients ingredients) {
            return Rebis >= ingredients.Rebis && Hydragenum >= ingredients.Hydragenum &&
                   Vermillion >= ingredients.Vermillion && Vitriol >= ingredients.Vitriol &&
                   Aether >= ingredients.Aether && Quebrith >= ingredients.Quebrith;
        }

        public bool IsEmpty() {
            return GetType().GetProperties().All(a => a.GetValue(this) == null);
        }

        public void SetDefaultValues() {
            foreach (var propertyInfo in GetType().GetProperties()
                .Where(a => a.GetValue(this) == null)) {
                propertyInfo.SetValue(this, 0);
            }
        }
    }
}