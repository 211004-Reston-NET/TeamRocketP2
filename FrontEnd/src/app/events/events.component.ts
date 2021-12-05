import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RevAPIService } from '../services/rev-api.service';
import { Evento } from '../models/Event';
import { elementAt } from 'rxjs';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})

export class EventsComponent implements OnInit
{

  listOfEvents:Evento[]=[];

  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit()
  {
    this.revApi.Event().subscribe((response)=>
    {
      console.log(response);

      response.forEach(element =>
      {
        this.listOfEvents.push(element);
      });

      this.listOfEvents =this.listOfEvents.slice(1,4);

    });
  }

}