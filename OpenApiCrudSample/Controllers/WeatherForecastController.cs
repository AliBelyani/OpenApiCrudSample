using Microsoft.AspNetCore.Mvc;
using OpenApiCrudSample.Model;
using OpenApiCrudSample.Service;

namespace OpenApiCrudSample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _weatherForecastService.GetWeatherForecasts();
        //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //{
        //    Id = index + 1,
        //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //    TemperatureC = Random.Shared.Next(-20, 55),
        //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //})
        //.ToArray();
    }

    [HttpPost("AddWeatherForecast")]
    public IActionResult Post()
    {
        _weatherForecastService.AddWeatherForecasts();
        return Ok();
    }

    [HttpDelete("DeleteWeatherForecast/{id}")]
    public IActionResult Delete(int id)
    {
        _weatherForecastService.DeleteWeatherForecasts(id);
        return Ok();
    }
}
