using Newtonsoft.Json;
using System.Collections.Generic;

namespace testproject_specflow.DataEntities
{
    public class LocationResponse
    {
        [JsonProperty("post code")]
        public string PostCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonProperty("places")]
        public List<Place> Places { get; set; }
    }
}