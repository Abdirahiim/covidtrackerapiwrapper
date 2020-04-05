using Newtonsoft.Json;
using System.Collections.Generic;
using static CovidSharp.Models.LocationStats;
using static CovidSharp.Models.ShortStats;

namespace CovidSharp.Models
{
    /// <summary>
    /// Full statistics.
    /// </summary>
    public class FullStats
    {
        [JsonProperty("latest")]
        public LatestData Latest { get; set; }

        [JsonProperty("locations")]
        public List<LocationData> Locations { get; set; }
    }
}
