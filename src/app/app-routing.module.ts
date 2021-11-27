import { LoginComponent } from './login/login.component';
import { EventsComponent } from './events/events.component';
import { NewsComponent } from './news/news.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WeatherComponent } from './weather/weather.component';

const routes: Routes = [
  { path:'', component: HomeComponent},
  { path: 'home', component:HomeComponent},
  { path: 'weather', component: WeatherComponent},
  { path: 'news', component: NewsComponent},
  { path: 'events', component: EventsComponent},
  { path: 'login', component: LoginComponent}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
