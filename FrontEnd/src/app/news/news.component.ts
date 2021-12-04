import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { News } from '../models/news';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})

export class NewsComponent implements OnInit
{
  text2: string = "";
  resultado: string = "";
  listOfNewsArticles: News[] = [];
  title: string="";

  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit()
  {
    this.listOfNewsArticles=[];
    this.revApi.GeoHeadlines().subscribe((response) =>
    {
      console.log(response);
      for (var i in response.articles)
      {
        let n: News =
        {
          published: response.articles[i].published,
          title: response.articles[i].title,
          link: response.articles[i].link
        };
        this.listOfNewsArticles.push(n)
      }
      this.listOfNewsArticles = this.listOfNewsArticles.slice(0,8);
    });
    console.log(this.listOfNewsArticles);
  }

  JapaneseNews()
  {
    this.listOfNewsArticles=[];
    this.revApi.JapaneseHeadlines().subscribe((response) =>
    {
      console.log(response);
      for (var i in response.articles)
      {
        let test: News =
        {
          published: response.articles[i].published_date,
          title: response.articles[i].title,
          link: response.articles[i].link
        };
        this.listOfNewsArticles.push(test)
      }
      this.listOfNewsArticles = this.listOfNewsArticles.slice(0,8);
    });
    console.log(this.listOfNewsArticles);
  }

  translate(p_text: string)
  {
    this.text2 = p_text;
    this.revApi.translate(this.text2)
      .subscribe(data =>
      {
        this.resultado = data.data.translation;
        console.log(data);
      })
  }
}