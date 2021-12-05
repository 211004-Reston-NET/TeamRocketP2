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
