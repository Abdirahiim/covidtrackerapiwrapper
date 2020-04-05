using System;
using System.Linq;
using System.Threading.Tasks;

namespace CovidSharp.Net461Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var data = new CoronavirusData();

            var sources = await data.GetAvailableSourcesAsync();

            Output("Sources:");
            foreach (var source in sources)
            {
                OutputWithIndent(source);
            }

            // Fetches the latest common statistics.
            var shortInfo = await data.GetShortInfoAsync();
            Output("Short statistics:");
            OutputWithIndent("Confirmed: " + shortInfo.Latest.Confirmed);
            OutputWithIndent("Deaths: " + shortInfo.Latest.Deaths);
            OutputWithIndent("Recovered: " + shortInfo.Latest.Recovered);

            // Fetches the latest data of a country code.
            string country_code = "DK";
            var denmarkInfo = await data.GetFullInfoAsync(countryCode: country_code);
            Output("DK country code:");
            OutputWithIndent("Denmark Confirmed: " + denmarkInfo.Latest.Confirmed);
            OutputWithIndent("Denmark Recovered: " + denmarkInfo.Latest.Recovered);
            OutputWithIndent("Denmark Deaths: " + denmarkInfo.Latest.Deaths);
            OutputWithIndent("Denmark population: " + denmarkInfo.Locations.First().CountryPopulation);

            // Fetches data of a country Name.
            string country_name = "China";
            var chinaInfo = await data.GetFullInfoAsync(countryName: country_name);
            Output("China country name:");
            OutputWithIndent("China Confirmed: " + chinaInfo.Latest.Confirmed);
            OutputWithIndent("China Recovered: " + chinaInfo.Latest.Recovered);
            OutputWithIndent("China Deaths: " + chinaInfo.Latest.Deaths);
            OutputWithIndent("China population: " + chinaInfo.Locations.First().CountryPopulation);

            //Fetches the data of the Country/province associated with the ID
            var faroe_islands_id = 92;
            var faroeIslandsInfo = await data.GetInfoByLocationAsync(faroe_islands_id);
            Output("Faroe Islands country id:");
            OutputWithIndent("Name of the Faroe Islands: " + faroeIslandsInfo.Location.Province);
            OutputWithIndent("Name of the country of the Faroe Islands: " + faroeIslandsInfo.Location.Country);

            var denmark_id = 94;
            var denmarkStats = await data.GetInfoByLocationAsync(denmark_id);
            Output("Denmark country id:");
            OutputWithIndent("Denmark Latitude: " + denmarkStats.Location.Coordinates.Latitude);
            OutputWithIndent("Denmark Longtitude: " + denmarkStats.Location.Coordinates.Longitude);
            OutputWithIndent("Denmark Population: " + denmarkStats.Location.CountryPopulation);

            // Fetches lists of data, if not defined the default source will be jhu
            var fullInfo = await data.GetFullInfoAsync();
            var countries = fullInfo.Locations.Select(l => l.Country).ToArray();
            OutputWithIndent("Countries: " + string.Join(",", countries));

            var populations = fullInfo.Locations.Select(l => l.CountryPopulation).ToArray();
            OutputWithIndent("Populations: " + string.Join(",", populations));

            var provinces = fullInfo.Locations.Select(l => l.Province).ToArray();
            OutputWithIndent("Provinces: " + string.Join(",", provinces));

            var fullCSBSInfo = await data.GetFullInfoAsync("csbs");
            var counties = fullCSBSInfo.Locations.Select(l => l.County).ToArray();
            OutputWithIndent("Counties: " + string.Join(",", counties));

            Console.ReadKey(true);

            void Output(string s) => Console.WriteLine(s);
            void OutputWithIndent(string s) => Console.WriteLine("\t" + s);
        }
    }
}
