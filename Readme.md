# Coronavirus Tracker API Wrapper
This is a C# API wrapper for the Coronavirus tracking API(https://github.com/ExpDev07/coronavirus-tracker-api)

## Example
```c#
static void Main(string[] args)
        {
            // Declares the instance of the API
            CoronavirusData data = new CoronavirusData();
            
            // Fetches the latest data
            Console.WriteLine("Confirmed: " + data.LatestConfirmed());
            Console.WriteLine("Recovered: " + data.LatestRecovered());
            Console.WriteLine("Deaths: " + data.LatestDeaths());

            // Fetches the latest data of a country
            Console.WriteLine("Denmark Confirmed: " + data.FromCountryConfirmed("DK"));
            Console.WriteLine("Denmark Recovered: " + data.FromCountryRecovered("DK"));
            Console.WriteLine("Denmark Deaths: " + data.FromCountryDeaths("DK"));

            Console.ReadLine();
        }
    }
}
```
## Prerequisites
RestSharp
Newtonsoft.json

## Usage
Add the library and the prerequisites as references

## Installation
Will soon be available as a nuget package