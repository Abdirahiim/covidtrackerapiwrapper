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

            Console.ReadLine();
        }
    }
}
