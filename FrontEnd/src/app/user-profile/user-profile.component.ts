import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Users } from '../models/Users';
import { RevAPIService } from '../services/rev-api.service';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})

export class UserProfileComponent implements OnInit {

  @Input()
  userId:number = 0;

  @Input()
  show:boolean = true;

 
  listOfUserProfile:Users[]=[];
  

  constructor(private revApi: RevAPIService, private router: Router) { }




 

 
 

  ngOnInit(): void {
  }

}
// export class UserProfileComponent implements OnInit {

//   constructor(revApi:RevAPIService) { }

//   GetUserById() {
//     this.revApi.Users().subscribe((response) => {
//       console.log(response);
//       response.forEach(element => {
        
//         this.SingleUser.push(element);
//       });
//     });
      
//   }

//   ngOnInit(): void {
//   }
  

// }
