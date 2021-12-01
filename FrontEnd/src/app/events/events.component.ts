import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { News } from '../models/news';
import { Users } from '../models/Users';
import { Weather } from '../models/Weather';
import { RevAPIService } from '../services/rev-api.service';
import { Evento } from '../models/Event';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  text2: string = "";
  resultado: string = "";
  listOfNewsArticles: News[] = [];
  listOfWeatherForecast:Weather[]=[];
  listOfUsers:Users[]=[];
  listOfEvents:Evento[]=[];

  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit(): void {
  }


  getusers() {
    this.revApi.Users().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {
        
        this.listOfUsers.push(element);
      });
    });
      
  }

  Event() {
    this.revApi.Event().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {
        
        this.listOfEvents.push(element);
      });
    });
      
  }

}
