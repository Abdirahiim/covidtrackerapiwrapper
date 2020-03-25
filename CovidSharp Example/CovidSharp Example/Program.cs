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

            
            Console.WriteLine("Denmark Confirmed: " + data.FromCountryConfirmed("DK"));
            Console.WriteLine("Denmark Recovered: " + data.FromCountryRecovered("DK"));
            Console.WriteLine("Denmark Deaths: " + data.FromCountryDeaths("DK"));

            Console.WriteLine("Denmark ID Confirmed: " + data.FromIDConfirmed("94"));
            Console.WriteLine("Denmark  ID Recovered: " + data.FromCountryRecovered("94"));
            Console.WriteLine("Denmark ID Deaths: " + data.FromCountryDeaths("94"));

            Console.WriteLine("Name of the Faroe Islands: " + data.FromIDProvince("92"));
            Console.WriteLine("Name of the country of the Faroe Islands: " + data.FromIDCountry("92"));

            Console.WriteLine("Denmark Latitude: " + data.FromIDLatitude("94"));
            Console.WriteLine("Denmark Longtitude: " + data.FromIDLongitude("94"));


            Console.ReadLine();
        }
    }
}
