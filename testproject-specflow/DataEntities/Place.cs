using Newtonsoft.Json;

namespace testproject_specflow.DataEntities
{
    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("state")]
        public string State { get; set; } = "Schleswig-Holstein";
        [JsonProperty("state abbreviation")]
        public string StateAbbreviation { get; set; } = "SH";
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }
}