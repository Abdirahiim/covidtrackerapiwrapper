using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidSharp;

namespace Coronavirus_tracker_API_wrapper_example
{
    class Program
    {
        static void Main(string[] args)
        {
            CoronavirusData data = new CoronavirusData();

            Console.WriteLine("Confirmed: " + data.LatestConfirmed());
            Console.WriteLine("Recovered: " + data.LatestRecovered());
            Console.WriteLine("Deaths: " + data.LatestDeaths());


            // Fetches the latest data of a country code.
            string country_code = "DK";
            Console.WriteLine("Denmark Confirmed: " + data.FromCountryCodeConfirmed(country_code));
            Console.WriteLine("Denmark Recovered: " + data.FromCountryCodeRecovered(country_code));
            Console.WriteLine("Denmark Deaths: " + data.FromCountryCodeDeaths(country_code));
            Console.WriteLine("Denmark population: " + data.FromCountryCodePopulation(country_code));

            // Fetches data of a country Name.
            string country_name = "China";
            Console.WriteLine("China Confirmed: " + data.FromCountryNameConfirmed(country_name));
            Console.WriteLine("China Recovered: " + data.FromCountryNameRecovered(country_name));
            Console.WriteLine("China Deaths: " + data.FromCountryNameDeaths(country_name));
            Console.WriteLine("China population: " + data.FromCountryNamePopulation(country_name));

            //Fetches the data of the Country/province associated with the ID
            Console.WriteLine("Name of the Faroe Islands: " + data.FromIDProvince("92"));
            Console.WriteLine("Name of the country of the Faroe Islands: " + data.FromIDCountry("92"));
            Console.WriteLine("Denmark Latitude: " + data.FromIDLatitude("94"));
            Console.WriteLine("Denmark Longtitude: " + data.FromIDLongitude("94"));
            Console.WriteLine("Denmark Population: " + data.FromIDPopulation("94"));

            // Fetches lists of data, if not defined the default source will be jhu
             Console.WriteLine(data.GetCountryList());
             Console.WriteLine(data.GetPopulationList());
             Console.WriteLine(data.GetProvinceList());
             Console.WriteLine(data.GetCountyList("csbs")); //The source is set to csbs


            Console.ReadLine();
        }
    }
}
