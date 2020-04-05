using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CovidSharp.Extensions;
using CovidSharp.Models;
using Newtonsoft.Json.Linq;

namespace CovidSharp
{
    /// <summary>
    /// Represents data that retrieved from <see href="https://github.com/ExpDev07/coronavirus-tracker-api"/> api.
    /// </summary>
    public class CoronavirusData
    {
        private const string ApiAddress = "https://coronavirus-tracker-api.herokuapp.com/v2/";

        private readonly HttpClient _httpClient;

        public CoronavirusData()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiAddress)
            };
        }

        /// <summary>
        /// Gets available sources that can be used to get statistics.
        /// </summary>
        /// <returns>Available sources.</returns>
        public async Task<string[]> GetAvailableSourcesAsync()
        {
            var result = await ExecuteGetAsync($"sources/");

            return JObject
                .Parse(result)
                .SelectTokens("sources")
                .Values<string>()
                .ToArray();
        }

        /// <summary>
        /// Gets short statistics (count of confirmed, deaths and recovered).
        /// </summary>
        /// <param name="source">Source to get statistics (default is jhu).</param>
        /// <returns>Short statistics about virus propagation.</returns>
        public async Task<ShortStats> GetShortInfoAsync(string source = null)
        {
            var parameters = new Dictionary<string, string>();

            parameters.AddIfNotNullOrEmpty("source", source);

            var result = await ExecuteGetAsync($"latest/", parameters);

            return JsonConvert.DeserializeObject<ShortStats>(result);
        }

        /// <summary>
        /// Gets full statistics.
        /// </summary>
        /// <param name="source">Source to get statistics (default is jhu).</param>
        /// <param name="countryName">Country name.</param>
        /// <param name="countryCode">Country code <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2"/></param>
        /// <param name="province">Province.</param>
        /// <param name="county">County.</param>
        /// <param name="timelines">Timelines visibility (default is 0).</param>
        /// <returns>Full statistics about virus propagation.</returns>
        public async Task<FullStats> GetFullInfoAsync(string source = null, string countryName = null, string countryCode = null, string province = null, string county = null, bool? timelines = null)
        {
            var parameters = new Dictionary<string, string>();

            parameters.AddIfNotNullOrEmpty("source", source);
            parameters.AddIfNotNullOrEmpty("country", countryName);
            parameters.AddIfNotNullOrEmpty("country_code", countryCode);
            parameters.AddIfNotNullOrEmpty("province", province);
            parameters.AddIfNotNullOrEmpty("county", county);
            parameters.AddIfNotNullOrEmpty("timelines", timelines?.ToString());

            var result = await ExecuteGetAsync($"locations/", parameters);

            return JsonConvert.DeserializeObject<FullStats>(result);
        }

        /// <summary>
        /// Gets statistics about specified location.
        /// </summary>
        /// <param name="id">Location id.</param>
        /// <param name="source">Source to get statistics (default is jhu).</param>
        /// <param name="timelines">Timelines visibility (default is 0).</param>
        /// <returns>Statistics about virus propagation inside specified location.</returns>
        public async Task<LocationStats> GetInfoByLocationAsync(int id = 0, string source = null, bool? timelines = null)
        {
            var parameters = new Dictionary<string, string>();

            parameters.AddIfNotNullOrEmpty("source", source);
            parameters.AddIfNotNullOrEmpty("timelines", timelines?.ToString().ToLower());

            var result = await ExecuteGetAsync($"locations/{id}", parameters);

            return JsonConvert.DeserializeObject<LocationStats>(result);
        }

        private async Task<string> ExecuteGetAsync(string method, Dictionary<string, string> parameters = null)
        {
            var responseParameters = parameters.IsNullOrEmpty() ?
                string.Empty
                :
                "?" + parameters.ToString(valueSeparator: "=", pairSeparator: "&");

            var response = await _httpClient.GetAsync(method + responseParameters);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
