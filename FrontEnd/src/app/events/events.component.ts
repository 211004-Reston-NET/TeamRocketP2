import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RevAPIService } from '../services/rev-api.service';
import { Evento } from '../models/Event';
import { elementAt } from 'rxjs';
import { Invite } from '../models/Invite';
import { AuthService } from '@auth0/auth0-angular';
import { Users } from '../models/Users';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})

export class EventsComponent implements OnInit
{

  listOfEvents:Evento[]=[];
  email:any;
  recipient:string=""
  current:Users={id:"",
  userName:"",
  userPass:"",
  email:"",
  nameOfUser:"",
  forums:"",
  invites:"",
  posts:"",
  replies:""}
eventsidnum:any;
  retrieved:any;
  show:boolean=false;

constructor(private revApi: RevAPIService, private router: Router,public auth0:AuthService) {
  this.auth0.user$.subscribe((Response) => {
    this.retrieved = Response?.name;
  });
 }

  ngOnInit()
  {
    this.revApi.Event().subscribe((response)=>
    {
      console.log(response);

      response.forEach(element =>
      {
        this.listOfEvents.push(element);
      });

      this.listOfEvents =this.listOfEvents.slice(1,6);
      console.log(this.listOfEvents)

    });
    this.revApi.CurrentUser(this.retrieved).subscribe((response) => {
      console.log(response);
      this.current=response;});
  }

  Invite(p_email: string,p_eventId:string,p_UserId:string,p_show:Evento)
  {
    console.log(p_show);
    let invitation:Invite = {
      UserId:p_UserId,
      emailRecipient:p_email,
      eventId:6
    };
    console.log(invitation)
    this.revApi.SendInvite(invitation)
      .subscribe(data =>
      {
        
        console.log(data);
      });
      this.router.navigateByUrl("/japan");
      
  }
  showform(p_id:string)
  {
    this.show=!this.show
    this.eventsidnum=p_id;
console.log(this.eventsidnum)
  }

}