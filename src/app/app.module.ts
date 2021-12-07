import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';

import {MatCardModule} from '@angular/material/card';
import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { AuthModule } from '@auth0/auth0-angular';
import {FlexLayoutModule} from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { WeatherComponent } from './weather/weather.component';
import { NewsComponent } from './news/news.component';
import { EventsComponent } from './events/events.component';
import { LoginComponent } from './login/login.component';
import { LandingComponent } from './landing/landing.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { ForumComponent } from './forum/forum.component';
import { CreateForumComponent } from './create-forum/create-forum.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { CreateReplyComponent } from './create-reply/create-reply.component';
import { PostsComponent } from './posts/posts.component';
import { RepliesComponent } from './replies/replies.component';
import { InviteComponent } from './invite/invite.component';

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    NewsComponent,
    EventsComponent,
    LoginComponent,
    LandingComponent,
    NavbarComponent,
    FooterComponent,
    ForumComponent,
    CreateForumComponent,
    CreatePostComponent,
    CreateReplyComponent,
    PostsComponent,
    RepliesComponent,
    InviteComponent,
  ],

  imports: [
    AuthModule.forRoot({
      clientId: "UInoKfY6haP5fUKrz8V9sWhGkJ8lwAer",
      domain: "dev-c5jmjc96.us.auth0.com"
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
    ReactiveFormsModule,
    FontAwesomeModule,
    FlexLayoutModule

  ],

  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
