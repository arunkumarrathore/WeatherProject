namespace WeatherAPI.WeatherMap.Inerface
{
    using System.IO;


    public interface IWeatherMap
    {
        Stream GetWeatherDetailsForCity(string cityId);

    }
}
