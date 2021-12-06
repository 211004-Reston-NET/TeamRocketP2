import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Forums } from '../models/Forums';
import { RevAPIService } from '../services/rev-api.service';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ForumPosts } from '../models/ForumPosts';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})

export class CreatePostComponent implements OnInit
{

    restGroup:FormGroup = new FormGroup({
      textfield: new FormControl("", Validators.required),
      date: new FormControl("", Validators.required)
    });
    showAddPost:boolean=false;
    @Input()
  restId:number = 0;
  @Input()
  showbutton:boolean = false;

    constructor(private p_Service:RevAPIService, private router: Router) { }

    ngOnInit(): void
    {
    }

    showForm()
    {
      this.showAddPost=!this.showAddPost
      console.log(this.showAddPost);
    }

    createPost(restGroup: FormGroup)
    {
      //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
      if (restGroup.valid) {
        let restaurant:ForumPosts = {
          postText: restGroup.get("textfield")?.value,
          dateCreated: restGroup.get("date")?.value,
          userId:8,
          forumId:this.restId,
          show:false
        };

        console.log(restaurant);

        this.p_Service.AddPost(restaurant).subscribe(
          (response) => {
            console.log(response);
            this.router.navigateByUrl("/forum");
          }
        )
      }
    }
  }
