using System.Collections.Generic;

namespace WitcherAPI.Models {
    public class Bomb {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Base { get; set; }
        public string Range { get; set; }
        public int Description { get; set; }
    }
}