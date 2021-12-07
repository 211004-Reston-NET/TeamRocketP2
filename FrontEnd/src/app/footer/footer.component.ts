import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  text2: string = "";
  resultado: string = "";
  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit(): void {
  }
  

}
