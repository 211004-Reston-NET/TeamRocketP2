import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RevAPIService } from '../services/rev-api.service';
import { AuthService } from '@auth0/auth0-angular';
import { Users } from '../models/Users';
import { DOCUMENT, NgIf} from '@angular/common';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  text2: string = "";
  resultado: string = "";

  constructor(private revApi: RevAPIService, private router: Router,public auth0:AuthService,@Inject(DOCUMENT) public document:Document,) { }

  ngOnInit(): void {
  }

  translate(p_text: string)
  {
    this.text2 = p_text;
    this.revApi.translate(this.text2)
      .subscribe(data =>
      {
        this.resultado = data.data.translation;
        console.log(data);
      });
      this.text2="";
  }

}