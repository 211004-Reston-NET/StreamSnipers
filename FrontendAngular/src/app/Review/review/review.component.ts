import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Review } from 'src/app/models/review';
import { WebAPIService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  constructor(private webAPI:WebAPIService) { }
  currentRate = 0;

  reviewGroup:FormGroup = new FormGroup({
    text: new FormControl("", Validators.required)
  });

  ngOnInit(): void {
  }

  createReview(revGroup:FormGroup)
  { 
    if (revGroup.valid) 
    {
      let review:Review = {
        //setting userId to 1 just to test
        UserId: 1,
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
