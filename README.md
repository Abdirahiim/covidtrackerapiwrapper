# CovidSharp
[![All Contributors](https://img.shields.io/badge/all_contributors-2-orange.svg?style=flat-square)](#contributors-)
[![Build status](https://ci.appveyor.com/api/projects/status/g4v7ilorkumnr0e3?svg=true)](https://ci.appveyor.com/project/Abdirahiim/covidsharp)
[![NuGet](https://img.shields.io/nuget/v/CovidSharp.svg?label=NuGet)](https://www.nuget.org/packages/CovidSharp/)
![NuGet](https://img.shields.io/nuget/dt/CovidSharp.svg)
[![GitHub stars](https://img.shields.io/github/stars/Abdirahiim/covidtrackerapiwrapper)](https://github.com/Abdirahiim/covidtrackerapiwrapper/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/Abdirahiim/covidtrackerapiwrapper)](https://github.com/Abdirahiim/covidtrackerapiwrapper/network/members)
[![HitCount](http://hits.dwyl.com/Abdirahiim/covidtrackerapiwrapper.svg)](http://hits.dwyl.com/Abdirahiim/covidtrackerapiwrapper)

CovidSharp is a crossplatform C# API wrapper for the [Coronavirus tracking API](https://github.com/ExpDev07/coronavirus-tracker-api)



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

- Use a country code and fetch the data of that country
```c#
 Console.WriteLine("Denmark Confirmed: " + data.FromCountryConfirmed("DK"));
 Console.WriteLine("Denmark Recovered: " + data.FromCountryRecovered("DK"));
 Console.WriteLine("Denmark Deaths: " + data.FromCountryDeaths("DK"));
 Console.WriteLine("Denmark Population: " + data.FromCountryCodePopulation("DK"));
```
### Get Data by country name

- Use a country code and fetch the data of that country
```c#
   Console.WriteLine("China Confirmed: " + data.FromCountryNameConfirmed("China"));
   Console.WriteLine("China Recovered: " + data.FromCountryNameRecovered("China"));
   Console.WriteLine("China population: " + data.FromCountryNamePopulation("China"));
```

### Get Data by ID

You can use the associated ID of a province or country to get the desired information
You can find countries IDs [here](http://coronavirus-tracker-api.herokuapp.com/v2/locations)

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

- Get the country population associated with an ID
```c#
   Console.WriteLine("Denmark Population: " + data.FromIDPopulation("94"));
```

### Get a list of data

You can easily fetch a list of your desired data, the default source is always jhs

- Get a list of the all the countries in the world
```c#
  Console.WriteLine(data.GetCountryList());
```

- Get a list of the populations of all the countries in the world
```c#
  Console.WriteLine(data.GetPopulationList());
```

- Get a list of the provinces of all the countries in the world
```c#
  Console.WriteLine(data.GetProvinceList());
```

- Get a list of the counties in the US using CSBS as a source
```c#
  Console.WriteLine(data.GetCountyList("csbs"));
```





## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/Abdirahiim"><img src="https://avatars0.githubusercontent.com/u/13730460?v=4" width="100px;" alt=""/><br /><sub><b>Abdirahiim Yassin </b></sub></a><br /><a href="https://github.com/Abdirahiim/covidtrackerapiwrapper/commits?author=Abdirahiim" title="Code">💻</a> <a href="https://github.com/Abdirahiim/covidtrackerapiwrapper/commits?author=Abdirahiim" title="Documentation">📖</a> <a href="#example-Abdirahiim" title="Examples">💡</a> <a href="#maintenance-Abdirahiim" title="Maintenance">🚧</a> <a href="https://github.com/Abdirahiim/covidtrackerapiwrapper/commits?author=Abdirahiim" title="Tests">⚠️</a></td>
    <td align="center"><a href="https://github.com/haseeb-heaven"><img src="https://avatars0.githubusercontent.com/u/11544739?v=4" width="100px;" alt=""/><br /><sub><b>HaseeB Mir</b></sub></a><br /><a href="https://github.com/Abdirahiim/covidtrackerapiwrapper/commits?author=haseeb-heaven" title="Code">💻</a> <a href="#example-haseeb-heaven" title="Examples">💡</a></td>
    <td align="center"><a href="https://github.com/Raamyy"><img src="https://avatars3.githubusercontent.com/u/29176293?v=4" width="100px;" alt=""/><br /><sub><b>Ramy Gamal</b></sub></a><br /><a href="https://github.com/Abdirahiim/covidtrackerapiwrapper/commits?author=Raamyy" title="Documentation">📖</a></td>
    <td align="center"><a href="https://jacobtonder.dk"><img src="https://avatars1.githubusercontent.com/u/13803549?v=4" width="100px;" alt=""/><br /><sub><b>Jacob Tønder</b></sub></a><br /><a href="#maintenance-jacobtonder" title="Maintenance">🚧</a></td>
    <td align="center"><a href="https://github.com/Aleksey-Nikonov"><img src="https://avatars2.githubusercontent.com/u/11257605?v=4" width="100px;" alt=""/><br /><sub><b>Aleksey-Nikonov</b></sub></a><br /><a href="#ideas-Aleksey-Nikonov" title="Ideas, Planning, & Feedback">🤔</a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
