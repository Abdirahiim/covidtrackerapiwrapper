using System;
using System.Collections.Generic;
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
        public static IRestRequest request = new RestRequest("v2/latest", Method.GET);

        //Fetches the response from the API
        public IRestResponse response = client.Execute(request);

        public string LatestConfirmed()
        {
            string LatestConfirmedData = null;
            try
            {
                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'latest' node in the result variable
                var LatestData = output["latest"];

                //The 'confirmed' sub node of the 'latest' node  is fetched and converted into a string
                LatestConfirmedData = LatestData["confirmed"].ToString();

            }
            catch (NullReferenceException)
            {
                LatestConfirmedData = "Data not available";
            }
            return LatestConfirmedData;
        }

        public string LatestRecovered()
        {
            string LatestRecoveredData = null;
            try
            {
                //Deserializes the reponse
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'latest' node in the result variable
                 var LatestData = output["latest"];

                //The 'recovered' sub node of the 'latest' node  is fetched and converted into a string
                 LatestRecoveredData = LatestData["recovered"].ToString();
            }
            catch (NullReferenceException)
            {
                LatestRecoveredData = "Data not available";
            }
            return LatestRecoveredData;
        }

        public string LatestDeaths()
        {
            string LatestDeathsData = null;
            try
            {
                //Deserializes the response
                 JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                 //Stores the 'latest' node in the result variable
                 var LatestData = output["latest"];

                //The 'death' sub node of the 'latest' node  is fetched and converted into a string
                LatestDeathsData = LatestData["deaths"].ToString(); 
            }
            catch (NullReferenceException)
            {
                LatestDeathsData = "Data not available";
            }
            return LatestDeathsData;
        }

        public string GetCountryList(string source = "jhu")
        {
            string country_list = GetCountryData("country", source);
            return country_list;
        }

        public string GetPopulationList(string source = "jhu")
        {
            string population_list = GetCountryData("country_population", source);
            return population_list;
        }

        public string GetProvinceList(string source = "jhu")
        {
            string province_list = GetCountryData("province", source);
            return province_list;
        }

        public string GetCountyList(string source = "jhu")
        {
            string county_list = GetCountryData("county", source);
            return county_list;
        }

        //General method to get country data.
        private static string GetCountryData(string data_type, string source = "jhu")
        {
            string data_list = null;
            var data_set = new SortedSet<string>();
            try
            {
                //Sends a GET request to the API
                var request = new RestRequest("v2/locations?source=" + source, Method.GET);

                //Fetches the response from the API
                var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'locations' node
                var locations = output["locations"];
                JArray loc_arr = (JArray)locations;

                //Loop untill all countries and add them in HashSet to remove duplicates.
                for (int index = 0; index < loc_arr.Count; index++)
                {
                    string country_data = locations[index][data_type].ToString();
                    data_set.Add(country_data);
                }

                data_list = string.Join("\n", data_set);
            }
            catch (NullReferenceException ex)
            {
                data_list = "Data not available try changing source";
            }
            return data_list;
        }


        public string FromCountryCodeConfirmed(string country_code)
        {
            string CountryConfirmedData = null; 
            try
            {
                //Sends a GET request to the API
                 var request = new RestRequest("v2/locations?country_code=" + country_code, Method.GET);

                 //Fetches the response from the API
                 var response = client.Execute(request);
    
                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

               //Stores the 'latest' node in the LatestData variable
                var LatestData = output["latest"];

                //The 'confirmed' sub node of the 'latest' sub node  is fetched and converted into a string
                CountryConfirmedData = LatestData["confirmed"].ToString();
            }
            catch (Exception)
            {
                CountryConfirmedData = "Data not available";
            }
            
            return CountryConfirmedData;
        }

        public string FromCountryCodeRecovered(string country_code)
        {
            string CountryRecoveredData = null;
            try
            {
                //Sends a GET request to the API
                var request = new RestRequest("v2/locations?country_code=" + country_code, Method.GET);

                //Fetches the response from the API
                var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'latest' node in the LatestData variable
                var LatestData = output["latest"];

                //The 'recovered' sub node of the 'latest' sub node  is fetched and converted into a string
                CountryRecoveredData = LatestData["recovered"].ToString();
            }
            catch (NullReferenceException)
            {
                CountryRecoveredData = "Data not available";
            }

            return CountryRecoveredData;
        }

        public string FromCountryCodeDeaths(string country_code)
        {
            string CountryDeathsData = null;
            try
            {
                //Sends a GET request to the API
                var request = new RestRequest("v2/locations?country_code=" + country_code, Method.GET);

                //Fetches the response from the API
                var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'latest' node in the LatestData variable
                var LatestData = output["latest"];

                //The 'deaths' sub node of the 'latest' sub node  is fetched and converted into a string
                CountryDeathsData = LatestData["deaths"].ToString();
            }
            catch (NullReferenceException)
            {
                CountryDeathsData = "Data not available";
            }

            return CountryDeathsData;
        }

        public string FromCountryCodePopulation(string country_code)
        {
            string CountryCodePopulation = null;
            try
            { 
               //Sends a GET request to the API
                var request = new RestRequest("v2/locations?country_code=" + country_code, Method.GET);

                //Fetches the response from the API
                var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'locations' node in the location variable
                var Location = output["locations"];

                 //Stores the 'id' sub node in the TheID variable
                 var TheID = Location[0];
        
               //The 'country_population' sub node of the 'id' sub node  is fetched and converted into a string
               CountryCodePopulation = TheID["country_population"].ToString();

            }
            catch (NullReferenceException)
            {
                CountryCodePopulation = "Data not available";

            }
           
            return CountryCodePopulation;
        }

        public string FromCountryNameConfirmed(string country_name)
        {
            string CountryConfirmedData = null;
            try
            {
                 //Sends a GET request to the API
                var request = new RestRequest("v2/locations?country=" + country_name, Method.GET);

                //Fetches the response from the API
                 var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);
    
                //Stores the 'latest' node in the LatestData variable
                var LatestData = output["latest"];

                //The 'confirmed' sub node of the 'latest' sub node  is fetched and converted into a string
                CountryConfirmedData = LatestData["confirmed"].ToString();
            }
            catch (NullReferenceException)
            {
                CountryConfirmedData = "Data not available";
            }
           
            return CountryConfirmedData;
        }

        public string FromCountryNameRecovered(string country_name)
        {
            string CountryRecoveredData = null;
            try
            {
                //Sends a GET request to the API
                  var request = new RestRequest("v2/locations?country=" + country_name, Method.GET);

                //Fetches the response from the API
                var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'latest' node in the LatestData variable
                var LatestData = output["latest"];

                //The 'recovered' sub node of the 'latest' sub node  is fetched and converted into a string
                CountryRecoveredData = LatestData["recovered"].ToString();
            }
            catch (NullReferenceException)
            {
                CountryRecoveredData = "Data not available";
            }
            
            return CountryRecoveredData;
        }

        public string FromCountryNameDeaths(string country_name)
        {
            string CountryDeathsData = null;
            try
            {
                //Sends a GET request to the API
                var request = new RestRequest("v2/locations?country=" + country_name, Method.GET);

                //Fetches the response from the API
                var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'latest' node in the LatestData variable
                var LatestData = output["latest"];

                //The 'Deaths' sub node of the 'latest' sub node  is fetched and converted into a string
                CountryDeathsData = LatestData["deaths"].ToString();
            }
            catch (NullReferenceException)
            {
                CountryDeathsData = "Data not available";
            }
            
            return CountryDeathsData;
        }

        public string FromCountryNamePopulation(string country_name)
        {
            string CountryPopulationData = null;
            try
            {
                //Sends a GET request to the API
                var request = new RestRequest("v2/locations?country=" + country_name, Method.GET);

                //Fetches the response from the API
                var response = client.Execute(request);

                //Deserializes the response
                JObject output = (JObject)JsonConvert.DeserializeObject(response.Content);

                //Stores the 'locations' node in the location variable
                var Location = output["locations"];

                //Stores the 'id' sub node in the TheID variable
                var TheID = Location[0];

                //The 'country_population' sub node of the 'id' sub node  is fetched and converted into a string
                CountryPopulationData = TheID["country_population"].ToString();
            }
            catch (NullReferenceException)
            {
                CountryPopulationData = "Data not available";
            }
            
            return CountryPopulationData;
        }



        public string FromIDConfirmed(string ID)
        {
            string IDConfirmedData = null;
            try
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
                IDConfirmedData = LatestData["confirmed"].ToString();
            }
            catch (NullReferenceException)
            {
                IDConfirmedData = "Data not available";
            }
            
            return IDConfirmedData;
        }

        public string FromIDRecovered(string ID)
        {
            string IDRecoveredData = null;
            try
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
                IDRecoveredData = LatestData["recovered"].ToString();
            }
            catch (NullReferenceException)
            {
                IDRecoveredData = "Data not available";
            }

            return IDRecoveredData;
        }

        public string FromIDDeaths(string ID)
        {
            string IDDeathsData = null;
            try
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
                IDDeathsData = LatestData["deaths"].ToString();
            }
            catch (NullReferenceException)
            {
                IDDeathsData = "Data not available";
            }

            return IDDeathsData;
        }

        public string FromIDLongitude(string ID)
        {
            string IDLongitudeData = null;
            try
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
                IDLongitudeData = Coordinates["longitude"].ToString();
            }
            catch (NullReferenceException)
            {
                IDLongitudeData = "Data not available";
            }
            
            return IDLongitudeData;
        }

        public string FromIDLatitude(string ID)
        {
            string IDLatitudeData = null;
            try
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
                IDLatitudeData = Coordinates["latitude"].ToString();
            }
            catch (NullReferenceException)
            {
                IDLatitudeData = "Data not available";
            }

            return IDLatitudeData;
        }

        public string FromIDCountry(string ID)
        {
            string IDCountryName = null;
            try
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
                IDCountryName = TheID["country"].ToString();
            }
            catch (NullReferenceException)
            {
                IDCountryName = "Data not available";
            }
            
            return IDCountryName;
        }

        public string FromIDProvince(string ID)
        {
            string IDProvinceName = null;
            try
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
                IDProvinceName = TheID["province"].ToString();
            }
            catch (NullReferenceException)
            {
                IDProvinceName = "Data not available";
            }

            return IDProvinceName;
        }

        public string FromIDPopulation(string ID)
        {
            string IDPopulationName = null;
            try
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
                IDPopulationName = TheID["country_population"].ToString();
            }
            catch (NullReferenceException)
            {
                IDPopulationName = "Data not available";
            }

            return IDPopulationName;
        }

    }
}
