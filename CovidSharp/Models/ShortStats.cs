using Newtonsoft.Json;

namespace CovidSharp.Models
{
    /// <summary>
    /// Short statistics.
    /// </summary>
    public class ShortStats
    {
        [JsonProperty("latest")]
        public LatestData Latest { get; set; }

        public class LatestData
        {
            [JsonProperty("confirmed")]
            public int Confirmed { get; set; }

            [JsonProperty("deaths")]
            public int Deaths { get; set; }

            [JsonProperty("recovered")]
            public int Recovered { get; set; }
        }
    }
}
