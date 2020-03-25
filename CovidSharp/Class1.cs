using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace CovidSharp
{
    public class CoronavirusData
    {
        //Initiates client
        public static IRestClient client = new RestClient("https://coronavirus-tracker-api.herokuapp.com/");

        //Sends a GET request to the API
        public static IRestRequest  request = new RestRequest("v2/latest", Method.GET);

        //Fetches the response from the API
        public IRestResponse response = client.Execute(request);

        public string LatestConfirmed()
        {
            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);
 
            //Stores the 'latest' node in the result variable
            var LatestData = output["latest"];

            //The 'confirmed' sub node of the 'latest' node  is fetched and converted into a string
            var LatestConfirmedData = LatestData["confirmed"].ToString();
            return LatestConfirmedData;
        }

        public string LatestRecovered()
        {
            //Deserializes the reponse
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the result variable
            var LatestData = output["latest"];

            //The 'recovered' sub node of the 'latest' node  is fetched and converted into a string
            var LatestRecoveredData = LatestData["recovered"].ToString();
            return LatestRecoveredData;
        }

        public string LatestDeaths()
        {
            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the result variable
            var LatestData = output["latest"];

            //The 'death' sub node of the 'latest' node  is fetched and converted into a string
            var LatestDeathsData = LatestData["deaths"].ToString();
            return LatestDeathsData;
        }

        public string FromCountryConfirmed(string country)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?country_code=" + country, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the LatestData variable
            var LatestData = output["latest"];

            //The 'confirmed' sub node of the 'latest' sub node  is fetched and converted into a string
            var CountryConfirmedData = LatestData["confirmed"].ToString();
            return CountryConfirmedData;
        }

        public string FromCountryRecovered(string country)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?country_code=" + country, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the LatestData variable
            var LatestData = output["latest"];

            //The 'recovered' sub node of the 'latest' sub node  is fetched and converted into a string
            var CountryRecoveredData = LatestData["recovered"].ToString();
            return CountryRecoveredData;
        }

        public string FromCountryDeaths(string country)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?country_code=" + country, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the LatestData variable
            var LatestData = output["latest"];
      
            //The 'Deaths' sub node of the 'latest' sub node  is fetched and converted into a string
            var CountryDeathsData = LatestData["deaths"].ToString();
            return CountryDeathsData;
        }

        public string FromIDConfirmed(string ID)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?id=" + ID, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the LatestData variable
            var LatestData = output["latest"];

            //The 'confirmed' sub node of the 'latest' sub node  is fetched and converted into a string
            var IDConfirmedData = LatestData["confirmed"].ToString();
            return IDConfirmedData;
        }

         public string FromIDRecovered(string ID)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?id=" + ID, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the LatestData variable
            var LatestData = output["latest"];

            //The 'recovered' sub node of the 'latest' sub node  is fetched and converted into a string
            var IDRecovoredData = LatestData["recovered"].ToString();
            return IDRecovoredData;
        }

        public string FromIDDeaths(string ID)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?id=" + ID, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'latest' node in the LatestData variable
            var LatestData = output["latest"];

            //The 'deaths' sub node of the 'latest' sub node  is fetched and converted into a string
            var IDDeathsData = LatestData["deaths"].ToString();
            return IDDeathsData;
        }

        public string FromIDLongitude(string ID)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?id=" + ID, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'locations' node in the location variable
            var Location = output["locations"];

            //Stores the 'id' sub node in the TheID variable
            var TheID = Location[0];

            //Stores the 'Coordinates' node in the LatestData variable
            var Coordinates = TheID["coordinates"];

            //The 'longitude' sub node of the 'id' sub node  is fetched and converted into a string
            var IDLongitudeData = Coordinates["longitude"].ToString();
            return IDLongitudeData;
        }

        public string FromIDLatitude(string ID)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?id=" + ID, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'locations' node in the location variable
            var Location = output["locations"];

            //Stores the 'id' sub node in the TheID variable
            var TheID = Location[0];

            //Stores the 'Coordinates' node in the LatestData variable
            var Coordinates = TheID["coordinates"];

            //The 'latitude' sub node of the 'id' sub node  is fetched and converted into a string
            var IDLatitudeData = Coordinates["latitude"].ToString();
            return IDLatitudeData;
        }

        public string FromIDCountry(string ID)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?id=" + ID, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'locations' node in the location variable
            var Location = output["locations"];

            //Stores the 'id' sub node in the TheID variable
            var TheID = Location[0];

            //The 'country' sub node of the 'id' sub node  is fetched and converted into a string
            var IDCountryName = TheID["country"].ToString();
            return IDCountryName;
        }

        public string FromIDProvince(string ID)
        {
            //Sends a GET request to the API
            var request = new RestRequest("v2/locations?id=" + ID, Method.GET);

            //Fetches the response from the API
            var response = client.Execute(request);

            //Deserializes the response
            JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

            //Stores the 'locations' node in the location variable
            var Location = output["locations"];

            //Stores the 'id' sub node in the TheID variable
            var TheID = Location[0];

            //The 'province' sub node of the 'id' sub node  is fetched and converted into a string
            var IDProvinceName = TheID["province"].ToString();
            return IDProvinceName;
        }

    }
}
