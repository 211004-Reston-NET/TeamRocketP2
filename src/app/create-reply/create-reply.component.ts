import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RevAPIService } from '../services/rev-api.service';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ForumPosts } from '../models/ForumPosts';
import { Replies } from '../models/Replies';

@Component({
  selector: 'app-create-reply',
  templateUrl: './create-reply.component.html',
  styleUrls: ['./create-reply.component.css']
})
export class CreateReplyComponent implements OnInit {

  restGroup:FormGroup = new FormGroup({
    textfield: new FormControl("", Validators.required),
    date: new FormControl("", Validators.required)
  });
  showAddReply:boolean=false;
  @Input()
  postIdentification:number = 0;
  @Input()
  showbutton:boolean = false;
  @Input()
  forumIdentification:number = 0;

  constructor(private p_Service:RevAPIService, private router: Router) { }

  ngOnInit(): void {
  }
  showForm()
  {
    this.showAddReply=!this.showAddReply

  }
  createReply(restGroup: FormGroup)
  {
    //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
    if (restGroup.valid)
     {
        let restaurant:Replies =
        {
        replyText: restGroup.get("textfield")?.value,
        dateCreated: restGroup.get("date")?.value,
        userId:8,
        forumId:this.forumIdentification,
        postId:this.postIdentification
        };

      console.log(restaurant);

      this.p_Service.AddReply(restaurant).subscribe
      (
        (response) => {
          console.log(response);
          this.router.navigateByUrl("/forum");
        }
      )
    }
  }
}
