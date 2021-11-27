import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { News } from '../models/news';
import { Weather } from '../models/Weather';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {
  text2: string = "";
  resultado: string = "";
  listOfNewsArticles: News[] = [];
  listOfWeatherForecast:Weather[]=[];

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


  News2() {
    this.listOfNewsArticles=[];

    this.revApi.GeoHeadlines().subscribe((response) => {
      console.log(response);
      //let pokemon2=JSON.parse(response);
      //console.log(pokemon2);
      for (var i in response.articles) {
        let test: News = {
          published: response.articles[i].published,
          title: response.articles[i].title,
          link: response.articles[i].link
        };
        this.listOfNewsArticles.push(test);
      }
      //It will set the show property to false to each element and also add it to our listOfRest


    });

  }


  JapaneseNews() {
this.listOfNewsArticles=[];
    this.revApi.JapaneseHeadlines().subscribe((response) => {
      console.log(response);
      //let pokemon2=JSON.parse(response);
      //console.log(pokemon2);
      for (var i in response.articles) {
        let test: News = {
          published: response.articles[i].published_date,
          title: response.articles[i].title,
          link: response.articles[i].link
        };
        this.listOfNewsArticles.push(test);
      }
      //It will set the show property to false to each element and also add it to our listOfRest


    });

  }

}
