import { Component,Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { News } from '../models/news';
import { Weather } from '../models/Weather';
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
  listOfNewsArticles: News[] = [];
  listOfWeatherForecast:Weather[]=[];
  weatherItemDate:Weather={temp:"",minimum:"",maximum:"",date:""};
  sunrise:string ="";

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
        this.weatherResult = "Current weather in " + p_weathertext + " is " + data.main.temp + " degrees F";

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
        this.sunrise=response.city.sunrise;
       // this.weatherItemDate=response.list[i].dt_txt;
        this.listOfWeatherForecast.push(test);
        this.weatherItemDate=this.listOfWeatherForecast[0];
      }

      //It will set the show property to false to each element and also add it to our listOfRest


    });
    

  }



}
