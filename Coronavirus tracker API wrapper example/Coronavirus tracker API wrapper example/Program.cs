using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronavirusApiWrapper;

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

            Console.ReadLine();
        }
    }
}
