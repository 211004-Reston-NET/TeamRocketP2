import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Forums } from '../models/Forums';
import { RevAPIService } from '../services/rev-api.service';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-forum',
  templateUrl: './create-forum.component.html',
  styleUrls: ['./create-forum.component.css']
})

export class CreateForumComponent implements OnInit

{

  restGroup:FormGroup = new FormGroup
  ({

    textfield: new FormControl("", Validators.required),
    date: new FormControl("", Validators.required)

  });

  showAddForum:boolean=false;
  @Input()
  currentuser:any

  constructor(private p_Service:RevAPIService, private router: Router) { }


ngOnInit(): void
{
}

showForm()
  {
    this.showAddForum=!this.showAddForum

  }
createForum(restGroup: FormGroup)
  {
    //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
    if (restGroup.valid) {
      let restaurant:Forums = {
        topicName: restGroup.get("textfield")?.value,
        dateCreated: restGroup.get("date")?.value,
        creatorId:this.currentuser,
        show:false
      };

      console.log(restaurant);

      this.p_Service.AddForum(restaurant).subscribe(
        (response) => {
          console.log(response);
          this.router.navigateByUrl("/japan");
        }
      )
    }
  }
}