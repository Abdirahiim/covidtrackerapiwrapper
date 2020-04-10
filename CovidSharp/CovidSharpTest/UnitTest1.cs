using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CovidSharp;

namespace CovidSharpTest
{
    [TestClass]
    public class UnitTest1
    {
        CoronavirusData data = new CoronavirusData();

        [TestMethod]
        public void TestLatestConfirmed()
        {
            //Actual Latest Confirmed numbers 
            var ActualLatestConfirmed = data.LatestConfirmed();

            //Insert here the current confirmed numbers in the API
            var ExpectedLatestConfirmed = "1595350";

            //Checks if the two values are equal
            Assert.AreEqual(ExpectedLatestConfirmed,ActualLatestConfirmed);
        }

        [TestMethod]
        public void TestLatestRecovered()
        {
            //Actual Latest recovered numbers 
            var ActualLatestRecovered = data.LatestRecovered();

            //Insert here the current recovered numbers in the API. It's currently 0 since jhu dropped the support for the recovered data
            var ExpectedLatestRecovered = "0";

            //Checks if the two values are equal
            Assert.AreEqual(ExpectedLatestRecovered, ActualLatestRecovered);
        }

        [TestMethod]
        public void TestLatestDeaths()
        {
            //Actual Latest deaths numbers 
            var ActualLatestDeaths = data.LatestDeaths();

            //Insert here the current deaths numbers in the API
            var ExpectedLatestDeaths = "95455";

            //Checks if the two values are equal
            Assert.AreEqual(ExpectedLatestDeaths, ActualLatestDeaths);
        }

        [TestMethod]
        public void TestFromCountryCodeConfirmed()
        {
            //Actual Confirmed numbers from the countrycode
            var ActualLatestConfirmed = data.FromCountryCodeConfirmed("DK");

            //Insert here the current confirmed numbers in the API
            var ExpectedLatestConfirmed = "5830";

            Assert.AreEqual(ExpectedLatestConfirmed, ActualLatestConfirmed);
        }

        [TestMethod]
        public void TestFromCountryCodeRecovered()
        {
            //Actual Latest recovered numbers 
            var ActualLatestRecovered = data.FromCountryCodeRecovered("DK");

            //Insert here the current recovered numbers in the API. It's currently 0 since jhu dropped the support for the recovered data
            var ExpectedLatestRecovered = "0";

            Assert.AreEqual(ExpectedLatestRecovered, ActualLatestRecovered);
        }

        [TestMethod]
        public void TestFromCountryCodeDeaths()
        {
            //Actual Latest deaths numbers 
            var ActualLatestDeaths = data.FromCountryCodeDeaths("DK");

            //Insert here the current deaths numbers in the API
            var ExpectedLatestDeaths = "237";

            Assert.AreEqual(ExpectedLatestDeaths, ActualLatestDeaths);
        }

        [TestMethod]
        public void TestFromCountryCodePopulation()
        {
            //Actual population
            var ActualPopulation = data.FromCountryCodePopulation("DK");

            //Insert here the current population number in the API
            var ExpectedPopulation = "5484000";

            Assert.AreEqual(ExpectedPopulation, ActualPopulation);
        }

        [TestMethod]
        public void TestFromCountryNameConfirmed()
        {
            //Actual Confirmed numbers from the countrycode
            var ActualLatestConfirmed = data.FromCountryNameConfirmed("Denmark");

            //Insert here the current confirmed numbers in the API
            var ExpectedLatestConfirmed = "5830";

            Assert.AreEqual(ExpectedLatestConfirmed, ActualLatestConfirmed);
        }

        [TestMethod]
        public void TestFromCountryNameRecovered()
        {
            //Actual Latest recovered numbers 
            var ActualLatestRecovered = data.FromCountryNameRecovered("Denmark");

            //Insert here the current recovered numbers in the API. It's currently 0 since jhu dropped the support for the recovered data
            var ExpectedLatestRecovered = "0";

            Assert.AreEqual(ExpectedLatestRecovered, ActualLatestRecovered);
        }

        [TestMethod]
        public void TestFromCountryNameDeaths()
        {
            //Actual Latest deaths numbers 
            var ActualLatestDeaths = data.FromCountryNameDeaths("Denmark");

            //Insert here the current deaths numbers in the API
            var ExpectedLatestDeaths = "237";

            Assert.AreEqual(ExpectedLatestDeaths, ActualLatestDeaths);
        }

        [TestMethod]
        public void TestFromCountryNamePopulation()
        {
            //Actual population
            var ActualPopulation = data.FromCountryNamePopulation("Denmark");

            //Insert here the current population number in the API
            var ExpectedPopulation = "5484000";

            Assert.AreEqual(ExpectedPopulation, ActualPopulation);
        }

        [TestMethod]
        public void TestFromIDConfirmed()
        {
            //Actual Confirmed numbers from the countrycode
            var ActualLatestConfirmed = data.FromIDConfirmed("94");

            //Insert here the current confirmed numbers in the API
            var ExpectedLatestConfirmed = "5635";

            Assert.AreEqual(ExpectedLatestConfirmed, ActualLatestConfirmed);
        }

        [TestMethod]
        public void TestFromIDRecovered()
        {
            //Actual Latest recovered numbers 
            var ActualLatestRecovered = data.FromIDRecovered("94");

            //Insert here the current recovered numbers in the API. It's currently 0 since jhu dropped the support for the recovered data
            var ExpectedLatestRecovered = "0";

            Assert.AreEqual(ExpectedLatestRecovered, ActualLatestRecovered);
        }

        [TestMethod]
        public void TestFromIDDeaths()
        {
            //Actual Latest deaths numbers 
            var ActualLatestDeaths = data.FromIDDeaths("94");

            //Insert here the current deaths numbers in the API
            var ExpectedLatestDeaths = "237";

            Assert.AreEqual(ExpectedLatestDeaths, ActualLatestDeaths);
        }

        [TestMethod]
        public void TestFromIDLongitude()
        {
            //Actual longitude 
            var ActualLongitude = data.FromIDLongitude("94");

            //Insert here the current longitude numbers in the API
            var ExpectedLongitude = "9.5018";

            Assert.AreEqual(ExpectedLongitude, ActualLongitude);
        }

        [TestMethod]
        public void TestFromIDLatitude()
        {
            //Actual latitude
            var ActualLatitude = data.FromIDLatitude("94");

            //Insert here the current latitude numbers in the API
            var ExpectedLatitude = "56.2639";

            Assert.AreEqual(ExpectedLatitude, ActualLatitude);
        }

        [TestMethod]
        public void TestFromIDProvince()
        {
            //Actual Province name
            var ActualProvinceName = data.FromIDProvince("92");

            //Insert here the  Province name in the API
            var ExpectedProvinceName = "Faroe Islands";

            Assert.AreEqual(ExpectedProvinceName, ActualProvinceName);
        }

        [TestMethod]
        public void TestFromIDPopulation()
        {
            //Actual Population number
            var ActualPopulation = data.FromIDPopulation("94");

            //Insert here the current population number in the API
            var ExpectedPopulation = "5484000";
          
            Assert.AreEqual(ExpectedPopulation, ActualPopulation);
        }
    }
}
