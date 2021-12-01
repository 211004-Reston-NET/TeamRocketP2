import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { News } from '../models/news';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-japan',
  templateUrl: './japan.component.html',
  styleUrls: ['./japan.component.css']
})
export class JapanComponent implements OnInit
{
  text2: string = "";
  resultado: string = "";
  listOfNewsArticles: News[] = [];
  title: string="";

  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit()
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
      this.listOfNewsArticles = this.listOfNewsArticles.slice(0,5);
    });
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
