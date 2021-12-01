import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ForumPosts } from '../models/ForumPosts';
import { RevAPIService } from '../services/rev-api.service';
@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit, OnChanges {
@Input()
  restId:number = 0;

  @Input()
  show:boolean = false;
  show2:boolean=false;

  listOfPosts:ForumPosts[]=[];
  overallRating:number = 0;
  constructor(private http:RevAPIService)
  { 

  }

  ngOnChanges(changes: SimpleChanges): void {
this.listOfPosts=[];
    this.http.PostsbyId(this.restId).subscribe((response) => {
      console.log(response);

      //It will set the show property to false to each element and also add it to our listOfUser
      response.forEach(element => {
        
        this.listOfPosts.push(element);
        
      });
    });
 
  }
  getPostsbyForumId(p_text:any)
  {
    this.show2=!this.show2;

  }
  showReview(p_id: number) {
    //This gets the current index of the element it found on the array
    let index: number = this.listOfPosts.findIndex(rest => rest.postId == p_id);

    //This flips that show property of it
    this.listOfPosts[index].show = !this.listOfPosts[index].show;

  }

  ngOnInit(): void {
  }

 

}
