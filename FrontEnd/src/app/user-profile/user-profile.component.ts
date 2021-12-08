import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Evento } from '../models/Event';
import { Invite } from '../models/Invite';
import { Users } from '../models/Users';
import { RevAPIService } from '../services/rev-api.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  listofInvitations:Invite[]=[];
  listofmyInvites:Invite[]=[];
  listOfEvents:Evento[]=[];
  show:boolean=false
  showComponent:boolean=false;

  retrieved:any
  current:Users={id:"",
    userName:"",
    userPass:"",
    email:"",
    nameOfUser:"",
    forums:"",
    invites:"",
    posts:"",
    replies:""}
  

  constructor(private revApi: RevAPIService, private router: Router,public auth0:AuthService) {
    this.auth0.user$.subscribe((Response) => {
      this.retrieved = Response?.email;
    });
    
   }


  ngOnInit(): void {
    this.revApi.CurrentUser(this.retrieved).subscribe((response) => {
      console.log(response);
      this.current=response;});
  
  this.revApi.GetInvites().subscribe((response) => {
    console.log(response);

    //It will set the show property to false to each element and also add it to our listOfUser
    response.forEach(element => {
        this.listofInvitations.push(element);
      
      });
  
  });
  this.revApi.Event().subscribe((response) => {
    console.log(response);

    //It will set the show property to false to each element and also add it to our listOfUser
    response.forEach(element => {
        this.listOfEvents.push(element);
      
      });
  
  });

 }

showMyinvites()
{
  this.listofmyInvites=[];
  for(var i in this.listofInvitations)
  {
    if(this.listOfEvents.findIndex(rest => rest.eventId == this.listofInvitations[i].eventId))
    {
      //console.log(this.listofInvitations[i].eventId);
      let index: number = this.listOfEvents.findIndex(rest => rest.eventId == this.listofInvitations[i].eventId);
      this.listofInvitations[i].activity=this.listOfEvents[index].eventName;
      //console.log(this.listofInvitations[i].activity)
    }
  }

  this.listofInvitations.forEach(element=>{
   
// console.log(this.current.email)
// console.log(element.emailRecipient)
    if(element.emailRecipient==this.current.email)
    {
      this.listofmyInvites.push(element)
    }
  });
  console.log(this.listofmyInvites)
  this.show=!this.show;
}

DeletefromList(p_id:string)
{
  this.revApi.DeleteInvite(p_id).subscribe((Response) => {
    console.log(Response);
    this.router.navigateByUrl("/forum");
  });
}

showForm()
{
  this.showComponent=!this.showComponent
}

}
