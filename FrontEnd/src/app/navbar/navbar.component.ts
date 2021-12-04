import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Users } from '../models/Users';
import { RevAPIService } from '../services/rev-api.service';
import { DOCUMENT, NgIf} from '@angular/common';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  
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

    
  constructor(private revApi: RevAPIService, private router: Router,public auth0:AuthService,@Inject(DOCUMENT) public document:Document,) {
    // this.auth0.user$.subscribe((Response) => {
    //   this.retrieved = Response?.name;
    // });
  }
     

  ngOnInit(): void {
    
      // this.revApi.CurrentUser(this.retrieved).subscribe((response) => {
      // console.log(response);
      // this.current=response;
      //     });
  
    
  }
  
}

