
namespace WeatherAPI.Controllers.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Net.Http;
    using System.Reflection;
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

            HttpResponseMessage result = weatherController.GetWeather($"{new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.Parent.FullName}\\WeatherAPI\\CityInfoTestPositive.txt");
            Assert.AreEqual(result.StatusCode,System.Net.HttpStatusCode.OK);
        }

        [TestMethod()]
        public void GetWeatherTest_BadRequest_NoData()
        {
            weatherMap = new WeatherMap();
            WeatherController weatherController = new WeatherController(weatherMap);
            weatherController.Request = new HttpRequestMessage();
            weatherController.Configuration = new HttpConfiguration();

            HttpResponseMessage result = weatherController.GetWeather($"{new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.Parent.FullName}\\WeatherAPI\\CityInfoTestNegative.txt");
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod()]
        public void GetWeatherTest_BadRequest_NoFile()
        {
            weatherMap = new WeatherMap();
            WeatherController weatherController = new WeatherController(weatherMap);
            weatherController.Request = new HttpRequestMessage();
            weatherController.Configuration = new HttpConfiguration();

            HttpResponseMessage result = weatherController.GetWeather($"{new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.Parent.FullName}\\WeatherAPI\\NoFile.txt");
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }


    }
}