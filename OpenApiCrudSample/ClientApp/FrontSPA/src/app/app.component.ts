import {Component} from '@angular/core';
import {WeatherForecastService} from "./api/services/weather-forecast.service";
import {WeatherForecast} from "./api/models/weather-forecast";
import {
  WeatherForecastDeleteWeatherForecastIdDelete$Params
} from "./api/fn/weather-forecast/weather-forecast-delete-weather-forecast-id-delete";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'OpenApiApplication';
  public weatherForecasts: WeatherForecast[] = [];

  constructor(private weatherService: WeatherForecastService) {
    this.getAllWeathers();
  }

  getAllWeathers() {
    this.weatherService.getWeatherForecast$Json().subscribe({
      next: (result) => this.weatherForecasts = result,
      error: (err) => console.log(err)
    });
  }

  addWeatherHandle() {
    this.weatherService.weatherForecastAddWeatherForecastPost$Response().subscribe({
      next: () => {
        alert("add new record success!");
        this.getAllWeathers();
      },
      error: (err) => console.log(err)
    });
  }

  removeWeatherHandler(id: any) {
    console.log(id)
    this.weatherService.weatherForecastDeleteWeatherForecastIdDelete({id}).subscribe({
      next: () => {
        console.log(id)
        alert("remove record success!");
        this.getAllWeathers();
      },
      error: (err) => console.log(err)
    })
  }
}
