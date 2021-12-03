import { DOCUMENT, NgIf} from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { RevAPIService } from '../services/rev-api.service';
import { Router } from '@angular/router';
import { Users } from '../models/Users';

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styleUrls: ['./auth-login.component.css']
})
export class AuthLoginComponent implements OnInit {

  name:string | undefined =""
  LogedInEmail:string | undefined =""
  LogedInPass:string | undefined =""
  email:string =""
  tempemail:string | undefined="notFound"
  VerifiedUser:Users | undefined;

  constructor(public auth0:AuthService, @Inject(DOCUMENT) public document:Document, private revApi: RevAPIService, private router: Router)
  { 
    this.auth0.user$.subscribe((Response) => {
      this.LogedInEmail = Response?.email;
      
      
    });
  }

  ngOnInit(): void {
 
  }
  verify(p_email?: string) {
    this.tempemail=p_email;
    this.revApi.Verify(this.tempemail)
      .subscribe(data => {
        console.log(data)
        this.VerifiedUser = data
        this.email = data.email

      })
  }
}



