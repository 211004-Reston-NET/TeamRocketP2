import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RevAPIService } from '../services/rev-api.service';
import { Users } from '../models/Users';
import { AuthService } from '@auth0/auth0-angular';
import { User } from '@auth0/auth0-spa-js';

@Component({
  selector: 'app-user-modify',
  templateUrl: './user-modify.component.html',
  styleUrls: ['./user-modify.component.css']
})
export class UserModifyComponent implements OnInit {
  restGroup:FormGroup = new FormGroup({
      Username: new FormControl("", Validators.required),
      PersonName: new FormControl("", Validators.required)
    });
    
    @Input()
    email:string="";
    @Input()
    showModifyUser:boolean = false;
    
    current:Users={
    id:"",
    userName:"",
    userPass:"",
    email:"",
    nameOfUser:"",
    forums:"",
    invites:"",
    posts:"",
    replies:""
  }

    retrieved:any

  constructor(public auth0:AuthService,private revApi:RevAPIService, private router: Router) { 
    this.auth0.user$.subscribe((Response) => {
      this.retrieved = Response?.name;
      });
  }

  ngOnInit(): void {
    this.revApi.CurrentUser(this.retrieved).subscribe((response) => {
      console.log(response);
      this.current=response;});
  }

  showForm(){
      this.showModifyUser=!this.showModifyUser
  
  }

  UpdateUserInfo(restGroup: FormGroup)
  {
      //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
      if (restGroup.valid) {
        let UserInfo:Users ={
          id: this.current.id,
          userName: restGroup.get("Username")?.value,
          nameOfUser:restGroup.get("PersonName")?.value,
          email: this.current.email,
          userPass:this.current.userPass,
          // forums: "",
          // posts: "",
          // replies:"",
          // invites:""
        }
        console.log(UserInfo);
        this.revApi.UpdateUser(UserInfo).subscribe(
          (response) => {
            console.log(response);
          }
        )
        this.router.navigateByUrl("/landing");
      }
 
  }

}
