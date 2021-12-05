import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '@auth0/auth0-spa-js';
import { ForumPosts } from '../models/ForumPosts';
import { Forums } from '../models/Forums';
import { Replies } from '../models/Replies';
import { Users } from '../models/Users';
import { RevAPIService } from '../services/rev-api.service';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent implements OnInit {

  listOfUsers:Users[]=[];
  listOfForums:Forums[]=[];
    userName2:string="";
    userPass2:string="";
    email2:string="";
    nameOfUser2:string="";

  listOfPosts:ForumPosts[]=[];
  listOfReplies:Replies[]=[];
  show: boolean = true;
  result:any="";
  replyshow:boolean=false;

  retrieved:any

  restGroup:FormGroup = new FormGroup({
    textfield: new FormControl("", Validators.required),
    date: new FormControl("", Validators.required)
  });

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
      this.retrieved = Response?.name;
    });
   }


  ngOnInit(): void {
    this.revApi.CurrentUser(this.retrieved).subscribe((response) => {
      console.log(response);
      this.current=response;});

    this.revApi.Forums().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {

        this.listOfForums.push(element);

      });
    });
      this.show=!this.show;
  }


  getusers()
  {
    this.revApi.Users().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {

        this.listOfUsers.push(element);
      });
    });

  }

  // getForums() {
  //   this.show = !this.show;
  //   this.revApi.Forums().subscribe((response) => {
  //     console.log(response);

  //     //It will set the show property to false to each element and also add it to our listOfUser
  //     response.forEach(element => {

  //       this.listOfForums.push(element);

  //     });
  //   });
  //     this.show=!this.show;
  // }

  getPosts()

  {
    this.revApi.Posts().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {

        this.listOfPosts.push(element);

      });
    });

  }

  getPostsbyForumId(p_text:any,p_show:any)
  {
    if(this.show != !p_show)
    {
      this.show = !p_show

    }
    else{
      this.show=p_show;
    }
    if(this.replyshow != !p_show)
    {
      this.replyshow = !p_show

    }
    else{
      this.replyshow=p_show;
    }

    this.result=p_text;

  }

  getReplies() {
    this.revApi.Reply().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {

        this.listOfReplies.push(element);

      });
    });

  }


  AddForum(P_Topic:string,P_date:string) {

    let testitem:Forums={topicName:P_Topic,dateCreated:P_date,creatorId:8,show:false}
      console.log(testitem);
      this.revApi.AddForum(testitem).subscribe((response) => {
        console.log(response);

        //It will set the show property to false to each element and also add it to our listOfUser

      });

    }


      AddReply(P_Topic:string,P_date:string) {

        let testitem:Replies={replyText:P_Topic,dateCreated:P_date,userId:8,forumId:this.result,postId:6}
          console.log(testitem);
          this.revApi.AddReply(testitem).subscribe((response) => {
            console.log(response);

            //It will set the show property to false to each element and also add it to our listOfUser

          });

        }
      }