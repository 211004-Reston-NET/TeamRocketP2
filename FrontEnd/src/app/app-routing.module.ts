import { HomeComponent } from './home/home.component';
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
  { path:'home', component: HomeComponent},
  { path: 'weather', component: WeatherComponent},
  { path: 'news', component: NewsComponent},
  { path: 'events', component: EventsComponent},
  { path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),],
  exports: [RouterModule]
})
export class AppRoutingModule { }
