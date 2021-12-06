import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatCardModule} from '@angular/material/card';
import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { AuthModule } from '@auth0/auth0-angular';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { WeatherComponent } from './weather/weather.component';
import { NewsComponent } from './news/news.component';
import { EventsComponent } from './events/events.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { LandingComponent } from './landing/landing.component';
import { RouterModule } from '@angular/router';
import { AuthLoginComponent } from './auth-login/auth-login.component';
import { ForumComponent } from './forum/forum.component';
import { FooterComponent } from './footer/footer.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
//import { FlexLayoutModule } from '@angular/flex-layout';
import { CreateForumComponent } from './create-forum/create-forum.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { CreateReplyComponent } from './create-reply/create-reply.component';
import { PostsComponent } from './posts/posts.component';
import { RepliesComponent } from './replies/replies.component';
import { ReactiveFormsModule } from '@angular/forms';
import { JapanComponent } from './japan/japan.component';
import { UserModifyComponent } from './user-modify/user-modify.component';

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    NewsComponent,
    EventsComponent,
    LoginComponent,
    LandingComponent,
    AuthLoginComponent,
    ForumComponent,
    FooterComponent,
    NavbarComponent,
    UserProfileComponent,
    CreateForumComponent,
    CreatePostComponent,
    CreateReplyComponent,
    PostsComponent,
    RepliesComponent,
    JapanComponent,
    UserModifyComponent
  ],

  imports: [
    AuthModule.forRoot({
      clientId:"YhFU5C8gk9d3y3SIVeRw8rGgmrFr6zLg",
      domain:"dev-i74lopba.us.auth0.com"
    }),
    
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatCardModule,
    MatTabsModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    FormsModule,
    //FlexLayoutModule,
    FontAwesomeModule,
    ReactiveFormsModule,
  ],

  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
