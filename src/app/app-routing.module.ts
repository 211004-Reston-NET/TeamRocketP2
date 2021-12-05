import { RepliesComponent } from './replies/replies.component';
import { Replies } from './models/Replies';
import { PostsComponent } from './posts/posts.component';
import { CreateReplyComponent } from './create-reply/create-reply.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { CreateForumComponent } from './create-forum/create-forum.component';
import { ForumComponent } from './forum/forum.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { EventsComponent } from './events/events.component';
import { NewsComponent } from './news/news.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WeatherComponent } from './weather/weather.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

const routes: Routes = [

  { path:'', component: LandingComponent},
  { path: 'weather', component: WeatherComponent},
  { path: 'news', component: NewsComponent},
  { path: 'events', component: EventsComponent},
  { path: 'login', component: LoginComponent},
  { path: 'forum', component: ForumComponent},
  { path: 'posts',component: PostsComponent},
  { path: 'replies',component: RepliesComponent},
  { path: '**', component: EventsComponent}

];

@NgModule({

  imports: [BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),],
  exports: [RouterModule]
})

export class AppRoutingModule { }
