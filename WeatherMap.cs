namespace WeatherAPI.WeatherMap.Implementation
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net.Http;
    using WeatherAPI.WeatherMap.Inerface;


    public class WeatherMap : IWeatherMap
    {
        public Stream GetWeatherDetailsForCity(string cityId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WeatherApiUrl"]);


            HttpResponseMessage response = client.GetAsync($"/data/2.5/weather?id={cityId}&appid={ConfigurationManager.AppSettings["AppId"]}").Result;

            return response.Content.ReadAsStreamAsync().Result;
        }
    }
}
