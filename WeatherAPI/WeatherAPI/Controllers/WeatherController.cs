namespace WeatherAPI.Controllers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WeatherAPI.Helpers;
    using WeatherMap.Implementation;
    using WeatherMap.Inerface;

    [RoutePrefix("Weather")]
    public class WeatherController : ApiController
    {
        private IWeatherMap weatherMap;

        /// <summary>
        /// WeatherMap Property
        /// </summary>
        public IWeatherMap WeatherMap
        {

            get
            {
                if (weatherMap == null)
                    weatherMap = new WeatherMap();
                return weatherMap;
            }
            set
            {
                weatherMap = value;
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public WeatherController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weatherMap"></param>
        public WeatherController(IWeatherMap weatherMap)
        {
            WeatherMap = weatherMap;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileUrl"></param>
        [HttpGet]
        [Route("GetWeather")]
        public HttpResponseMessage GetWeather(string fileUrl)
        {
            if (File.Exists(fileUrl))
            {
                // Read a text file line by line.
                string[] lines = File.ReadAllLines(fileUrl);
                if (lines == null || lines.Length == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found on specified file");
                }

                string filePath = string.Empty;
                foreach (string line in lines)
                {
                    string[] cityInfo = line.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                    try
                    {
                        Stream data = WeatherMap.GetWeatherDetailsForCity(cityInfo[0]);

                        filePath = FileHelper.SaveFile(data, fileUrl, cityInfo[1]);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, $"All file save at path : {filePath}");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No file found on specified url");
            }

        }
    }
}
