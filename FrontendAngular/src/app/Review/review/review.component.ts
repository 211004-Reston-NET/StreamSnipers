import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '@auth0/auth0-angular';
import { Review } from 'src/app/models/review';
import { WebAPIService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  constructor(private webAPI: WebAPIService, public auth0: AuthService) { }
  currentRate = 0;
  private userId:number = 0;
  reviewGroup:FormGroup = new FormGroup({
    text: new FormControl("", Validators.required)
  });

  ngOnInit(): void {
    // This is how we find the userId of who is logged in.
    this.auth0.user$.subscribe((user) => {
      if (user) {
        this.webAPI.getUserIdByEmail(user.email).subscribe((userId) => {
          this.userId = userId;
        });
      }
    });
  }

  createReview(revGroup:FormGroup)
  { 
    if (revGroup.valid) 
    {
      
      let review:Review = {
        UserId: this.userId,
        Text: revGroup.get("text")?.value,
        Rating: this.currentRate
      }
      console.log(review);
      this.webAPI.createReview(review).subscribe(
        (response) => {
          console.log(response);
        })
    }
  }

}
