import { ForumComponent } from './forum/forum.component';
import { JapanComponent } from './japan/japan.component';
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
import { AuthLoginComponent } from './auth-login/auth-login.component';

const routes: Routes = [

  { path:'', component: LandingComponent},
  { path: 'weather', component: WeatherComponent},
  { path: 'news', component: NewsComponent},
  { path: 'events', component: EventsComponent},
  { path: 'login', component: LoginComponent},
  { path: 'japan', component: JapanComponent},
  { path: 'forum', component: ForumComponent},
  { path: 'Authlogin', component: AuthLoginComponent},
  { path: '**', component: LandingComponent}


];

@NgModule({

  imports: [BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),],
  exports: [RouterModule]
})
export class AppRoutingModule { }
