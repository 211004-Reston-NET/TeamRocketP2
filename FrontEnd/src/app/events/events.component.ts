import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '@auth0/auth0-spa-js';
import { ForumPosts } from '../models/ForumPosts';
import { Forums } from '../models/Forums';
import { News } from '../models/news';
import { Replies } from '../models/Replies';
import { Users } from '../models/Users';
import { Weather } from '../models/Weather';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

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

  forumtopic:any="";
  forumdate:any="";

  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit(): void {

    this.revApi.Forums().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {
        
        this.listOfForums.push(element);
        
      });
    });
      this.show=!this.show;
  }


  getusers() {
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
  getPosts() {
    this.revApi.Posts().subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {
        
        this.listOfPosts.push(element);
        
      });
    });
      
  }
  getPostsbyForumId(p_text:any,p_show:any) {
if(this.show != !p_show)
{
  this.show = !p_show
}
else{
  this.show=p_show;
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
  


  AddUser(P_username:string,P_Pass:string,p_email:string,p_name:string) {
  
  let testitem:Users={userName:P_username,userPass:P_Pass,email:p_email,nameOfUser:p_name}
    console.log(testitem);
    this.revApi.AddUser(testitem).subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
     
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

    AddPost(P_Topic:string,P_date:string) {
  
      let testitem:ForumPosts={postText:P_Topic,dateCreated:P_date,userId:8,forumId:4,show:false}
        console.log(testitem);
        this.revApi.AddPost(testitem).subscribe((response) => {
          console.log(response);
    
          //It will set the show property to false to each element and also add it to our listOfUser
         
        });
          
      }
      AddReply(P_Topic:string,P_date:string) {
  
        let testitem:Replies={replyText:P_Topic,dateCreated:P_date,userId:8,forumId:4,postId:6}
          console.log(testitem);
          this.revApi.AddReply(testitem).subscribe((response) => {
            console.log(response);
      
            //It will set the show property to false to each element and also add it to our listOfUser
           
          });
            
        }





}

