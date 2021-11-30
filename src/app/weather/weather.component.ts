import { Weather } from './../models/Weather';
import { Component,Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { News } from '../models/news';
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
  listOfNewsArticles: News[] = [];
  listOfWeatherForecast:Weather[]=[];
  city: string="";
  weatherHumidity: any="";
  weatherTemp: any="";
  weatherWind: any="";
  weatherDescription: any="";

  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit(): void {
  }

  translate(p_text: string) {
    this.text2 = p_text;
    this.revApi.translate(this.text2)
      .subscribe(data => {
        this.resultado = data.data.translation;
        console.log(data);

      })
  }

  Weather(p_weathertext: string) {
    this.text2 = p_weathertext;
    this.revApi.GetCurrentWeather(this.text2)
      .subscribe(data => {
        console.log(data)
        // this.weatherResult = "Current weather in " + p_weathertext + " is " + data.main.temp + " degrees F";
        this.city=data.name;
        this.weatherTemp = data.main.temp;
        this.weatherHumidity = data.main.humidity+"%";
        this.weatherWind = data.wind.speed+ " mph";
        this.weatherDescription = data.weather[0].description;


      })

  }

  Forecast(p_text:string) {
    this.weatherText=p_text;
    this.listOfWeatherForecast=[];
    this.revApi.FiveDayForecast(this.weatherText).subscribe((response) => {
      console.log(response);
      //let pokemon2=JSON.parse(response);
      //console.log(pokemon2);
      for (var i in response.list) {
        let test: Weather = {
          temp: response.list[i].main.temp+" °F",
          minimum: response.list[i].main.temp_min+" °F",
          maximum: response.list[i].main.temp_max+" °F",
          date:response.list[i].dt_txt

        };

        this.listOfWeatherForecast.push(test);

      }
      //It will set the show property to false to each element and also add it to our listOfRest

    });

  }
}
