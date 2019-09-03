
namespace WeatherAPI.Controllers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net.Http;
    using System.Web.Http;
    using WeatherAPI.Controllers;
    using WeatherAPI.WeatherMap.Implementation;
    using WeatherAPI.WeatherMap.Inerface;

    [TestClass()]
    public class WeatherControllerTests
    {
        IWeatherMap weatherMap = null;

        [TestMethod()]
        public void GetWeatherTest_OK()
        {
            weatherMap = new WeatherMap();
            WeatherController weatherController = new WeatherController(weatherMap);
            weatherController.Request = new HttpRequestMessage();
            weatherController.Configuration = new HttpConfiguration();

            HttpResponseMessage result = weatherController.GetWeather(@"C:\Users\Arun.kumar1\source\repos\WeatherAPI\WeatherAPI\CityInfoTestPositive.txt");
            Assert.AreEqual(result.StatusCode,System.Net.HttpStatusCode.OK);
        }

        [TestMethod()]
        public void GetWeatherTest_BadRequest_NoData()
        {
            weatherMap = new WeatherMap();
            WeatherController weatherController = new WeatherController(weatherMap);
            weatherController.Request = new HttpRequestMessage();
            weatherController.Configuration = new HttpConfiguration();

            HttpResponseMessage result = weatherController.GetWeather(@"C:\Users\Arun.kumar1\source\repos\WeatherAPI\WeatherAPI\CityInfoTestNegative.txt");
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod()]
        public void GetWeatherTest_BadRequest_NoFile()
        {
            weatherMap = new WeatherMap();
            WeatherController weatherController = new WeatherController(weatherMap);
            weatherController.Request = new HttpRequestMessage();
            weatherController.Configuration = new HttpConfiguration();

            HttpResponseMessage result = weatherController.GetWeather(@"C:\Users\Arun.kumar1\source\repos\WeatherAPI\WeatherAPI\NoFile.txt");
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }


    }
}