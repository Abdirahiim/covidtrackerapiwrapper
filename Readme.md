# Coronavirus Tracker API Wrapper
This is a C# API wrapper for the Coronavirus tracking API(https://github.com/ExpDev07/coronavirus-tracker-api)

## Example
```c#
static void Main(string[] args)
        {
            // Declares the instance of the API
            CoronvirusData data = new CoronvirusData();
            
            // Fetches the latest data
            Console.WriteLine("Confirmed: " + data.LatestConfirmed());
            Console.WriteLine("Recovered: " + data.LatestRecovered());
            Console.WriteLine("Deaths: " + data.LatestDeaths());

            Console.ReadLine();
        }
    }
}
```
## Prerequisites
RestSharp
Newtonsoft.json

## Installation
Will soon be available as a nuget package