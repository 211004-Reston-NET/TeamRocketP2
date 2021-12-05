import { Weather } from './../models/Weather';
import { Component,Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})

export class WeatherComponent implements OnInit {

  text2: string = "";
  resultado: string = "";
  weatherText: string = "";
  weatherResult: string = "";
  listOfWeatherForecast:Weather[]=[];
  city: string="";
  Humidity: any="";
  Temp: any="";
  Wind: any="";
  Description: any="";
  listOfWeatherForecast2:Weather[]=[];
  testvalue:string="";

  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit(): void
  {

  }

  Weather(p_weathertext: string) {
    this.text2 = p_weathertext;
    this.revApi.GetCurrentWeather(this.text2)
      .subscribe(data => {
        console.log(data)
        // this.weatherResult = data.main.humidity + data.main.humidity + " is " + data.main.temp + " degrees F";
        this.city=data.name;
        this.Temp=data.main.temp+" °F";
        this.Description=data.weather[0].description;
        this.Humidity = data.main.humidity+"%";
        this.Wind = data.wind.speed+ " mph";
        document.querySelector(" .weather")?.classList.remove("loading");
      })
  }

  Forecast(p_text:string) {
    this.weatherText=p_text;
    this.listOfWeatherForecast=[];
    this.revApi.FiveDayForecast(this.weatherText).subscribe((response) => {
      console.log(response);
      // let pokemon2=JSON.parse(response);
      // console.log(pokemon2);
      for (var i in response.list) {
        let test: Weather = {
          temp: response.list[i].main.temp+" °F",
          minimum: response.list[i].main.temp_min+" °F",
          maximum: response.list[i].main.temp_max+" °F",
          date:response.list[i].dt_txt

        };
        this.listOfWeatherForecast.push(test);
      }
      this.listOfWeatherForecast2.push(this.listOfWeatherForecast[0]);
    this.listOfWeatherForecast2.push(this.listOfWeatherForecast[1]);

    console.log(this.listOfWeatherForecast2);

    });


    // let test: Weather = {
    //   temp: this.listOfWeatherForecast[0].temp,
    //   minimum: this.listOfWeatherForecast[0].minimum,
    //   maximum: this.listOfWeatherForecast[0].maximum,
    //   date:this.listOfWeatherForecast[0].date

    // };
    // this.listOfWeatherForecast2.push(test);

  }

  translate(p_text: string) {
    this.text2 = p_text;
    this.revApi.translate(this.text2)
      .subscribe(data => {
        this.resultado = data.data.translation;
        console.log(data);

      })
  }


}
