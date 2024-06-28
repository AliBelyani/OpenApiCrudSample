using OpenApiCrudSample.Model;

namespace OpenApiCrudSample.Service;

public class WeatherForecastService : IWeatherForecastService
{
    private static List<WeatherForecast> Weathers = new List<WeatherForecast>();

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherForecastService()
    {
        Weathers = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Id = index + 1,
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToList();
    }

    public List<WeatherForecast> GetWeatherForecasts() => Weathers;

    public void AddWeatherForecasts()
    {
        Weathers.Add(new WeatherForecast
        {
            Id = Random.Shared.Next(6, 100),
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });
    }

    public void DeleteWeatherForecasts(int id)
    {
        var weather = Weathers.FirstOrDefault(x => x.Id == id);
        if (weather != null)
            Weathers.Remove(weather);
    }
}