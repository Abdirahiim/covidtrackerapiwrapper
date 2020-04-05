using Newtonsoft.Json;
using System.Collections.Generic;
using static CovidSharp.Models.ShortStats;

namespace CovidSharp.Models
{
    /// <summary>
    /// Statistics of specified location.
    /// </summary>
    public class LocationStats
    {
        [JsonProperty("location")]
        public LocationData Location { get; set; }

        public class LocationData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("country_population")]
            public long? CountryPopulation { get; set; }

            [JsonProperty("province")]
            public string Province { get; set; }

            [JsonProperty("county")]
            public string County { get; set; }

            [JsonProperty("last_updated")]
            public string LastUpdated { get; set; }

            [JsonProperty("coordinates")]
            public CoordinatesData Coordinates { get; set; }

            public class CoordinatesData
            {
                [JsonProperty("longitude")]
                public string Longitude { get; set; }

                [JsonProperty("latitude")]
                public string Latitude { get; set; }
            }

            [JsonProperty("latest")]
            public LatestData Latest { get; set; }

            [JsonProperty("timelines")]
            public TimelinesData Timelines { get; set; }

            public class TimelinesData
            {
                [JsonProperty("confirmed")]
                public ConfirmedData Confirmed { get; set; }

                public class ConfirmedData
                {
                    [JsonProperty("latest")]
                    public int Latest { get; set; }

                    [JsonProperty("timeline")]
                    public Dictionary<string, string> Timeline { get; set; }
                }

                [JsonProperty("deaths")]
                public DeathsData Deaths { get; set; }

                public class DeathsData
                {
                    [JsonProperty("latest")]
                    public int Latest { get; set; }

                    [JsonProperty("timeline")]
                    public Dictionary<string, string> Timeline { get; set; }
                }

                [JsonProperty("recovered")]
                public RecoveredData Recovered { get; set; }

                public class RecoveredData
                {
                    [JsonProperty("latest")]
                    public int Latest { get; set; }

                    [JsonProperty("timeline")]
                    public Dictionary<string, string> Timeline { get; set; }
                }
            }
        }
    }
}
