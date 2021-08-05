using System.Collections.Generic;

namespace WitcherAPI.Models {
    public class Oil {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Base { get; set; }
        public string Duration { get; set; }
        public int Description { get; set; }
    }
}