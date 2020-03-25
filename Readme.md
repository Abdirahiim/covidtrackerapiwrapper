# CovidSharp
CovidSharp is a C# API wrapper for the [Coronavirus tracking API](https://github.com/ExpDev07/coronavirus-tracker-api)

[![NuGet](https://img.shields.io/nuget/v/CovidSharp.svg?label=NuGet)](https://www.nuget.org/packages/CovidSharp/)
![NuGet](https://img.shields.io/nuget/dt/CovidSharp.svg)
[![GitHub stars](https://img.shields.io/github/stars/Abdirahiim/covidtrackerapiwrapper)](https://github.com/Abdirahiim/covidtrackerapiwrapper/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/Abdirahiim/covidtrackerapiwrapper)](https://github.com/Abdirahiim/covidtrackerapiwrapper/network/members)
[![HitCount](http://hits.dwyl.com/Abdirahiim/covidtrackerapiwrapper.svg)](http://hits.dwyl.com/Abdirahiim/covidtrackerapiwrapper)

## Installation
You can install it as a [nuget package](https://www.nuget.org/packages/CovidSharp) 

## Usage

### Call the Library
```c#
using CovidSharp;
```
- Declares the instance of the library
```c#
CoronavirusData data = new CoronavirusData();
```

### Get the Latest Data

- Fetches the latest worldwide data
```c#
 Console.WriteLine("Confirmed: " + data.LatestConfirmed());
 Console.WriteLine("Recovered: " + data.LatestRecovered());
 Console.WriteLine("Deaths: " + data.LatestDeaths());
```

### Get Data by country code

- Use a country code and fetch the latest data of that country
```c#
 Console.WriteLine("Denmark Confirmed: " + data.FromCountryConfirmed("DK"));
 Console.WriteLine("Denmark Recovered: " + data.FromCountryRecovered("DK"));
 Console.WriteLine("Denmark Deaths: " + data.FromCountryDeaths("DK"));
```
### Get Data by ID

You can use the associated ID of a province or country to get the desired information

- This code gets the latest data of Denmark using ID instead of a country code
```c#
 Console.WriteLine("Denmark ID Confirmed: " + data.FromIDConfirmed("94"));
 Console.WriteLine("Denmark  ID Recovered: " + data.FromCountryRecovered("94"));
 Console.WriteLine("Denmark ID Deaths: " + data.FromCountryDeaths("94"));
```

- Get the province name associated with an ID, in this case the ID of 92 is associated with the Faroe Islands province
```c#
  Console.WriteLine("Name of the Faroe Islands: " + data.FromIDProvince("92"));
```

- Get the country name associated with an ID, in this case the ID of 92 is associated with the Faroe Islands province
```c#
  Console.WriteLine("Name of the country of the Faroe Islands: " + data.FromIDCountry("92"));
```

- Get the latitude associated with an ID
```c#
  Console.WriteLine("Denmark Latitude: " + data.FromIDLatitude("94"));
```

- Get the longitude associated with an ID
```c#
  Console.WriteLine("Denmark Longtitude: " + data.FromIDLongitude("94"));
```