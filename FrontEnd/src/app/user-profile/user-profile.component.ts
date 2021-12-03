import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Users } from '../models/Users';
import { RevAPIService } from '../services/rev-api.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})

export class UserProfileComponent implements OnInit {

  current:Users={id:"",
    userName:"",
    userPass:"",
    email:"",
    nameOfUser:"",
    forums:"",
    invites:"",
    posts:"",
    replies:""};
    retrieved:any
  constructor(private revApi: RevAPIService, private router: Router,public auth0:AuthService) {
    this.auth0.user$.subscribe((Response) => {
      this.retrieved = Response?.name;
    });
   }

  ngOnInit(): void {
    this.revApi.CurrentUser(this.retrieved).subscribe((response) => {
      console.log(response);
      this.current=response;
      

      //It will set the show property to false to each element and also add it to our listOfUser
     
    });
  
  }

}
