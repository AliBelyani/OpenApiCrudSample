using OpenApiCrudSample.Model;

namespace OpenApiCrudSample.Service;

public interface IWeatherForecastService
{
    List<WeatherForecast> GetWeatherForecasts();
    void AddWeatherForecasts();
    void DeleteWeatherForecasts(int id);
}
