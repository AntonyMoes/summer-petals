using System;
using Unity.Plastic.Newtonsoft.Json;

namespace _Game.Scripts.Data {
    [Serializable]
    public class Order {
        [JsonProperty] private string type;
        [JsonProperty] private string wrapping;
        [JsonProperty] private string description;

        public string Type => type;
        public string Wrapping => wrapping;
        public string Description => description;
    }
}