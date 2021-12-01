import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import {MatCardModule} from '@angular/material/card';
import {MatTabsModule} from '@angular/material/tabs';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { AuthModule } from '@auth0/auth0-angular';
import {FlexLayoutModule} from '@angular/flex-layout';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { WeatherComponent } from './weather/weather.component';
import { NewsComponent } from './news/news.component';
import { EventsComponent } from './events/events.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { LandingComponent } from './landing/landing.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { JapanComponent } from './japan/japan.component';

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
    JapanComponent,

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
    FontAwesomeModule,
    FlexLayoutModule

  ],

  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
