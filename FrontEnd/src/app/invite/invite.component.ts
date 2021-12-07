import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Invite } from '../models/Invite';
import { RevAPIService } from '../services/rev-api.service';

@Component({
  selector: 'app-invite',
  templateUrl: './invite.component.html',
  styleUrls: ['./invite.component.css']
})
export class InviteComponent implements OnInit {

  @Input()
  currentuser:any;
  @Input()
  activity:any;
  recipient:any;
  constructor(private revApi: RevAPIService, private router: Router) { }

  ngOnInit(): void {
  }
  Invite(p_email: string)
  {
    let invitation:Invite = {
      UserId:this.currentuser,
      emailRecipient:p_email,
      eventId:this.activity
    };
    console.log(invitation)
    this.revApi.SendInvite(invitation)
      .subscribe(data =>
      {
        
        console.log(data);
      });
      this.router.navigateByUrl("/landing");
      
  }
}
