import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { HomeComponent } from 'src/app/Home/home/home.component';
import { Review } from 'src/app/models/review';
import { UserModel } from 'src/app/models/user';
import { ImdbService } from 'src/app/services/imdb.service';
import { WebAPIService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  constructor(private webAPI: WebAPIService, public auth0: AuthService, private router: Router, private imdbAPI: ImdbService)
  {
    this.auth0.user$.subscribe((user) => {
      if (user) {
        this.webAPI.getUserByEmail(user.email).subscribe((userFound) => {
          this.user = userFound;
        });
      }
    });
  }
  currentRate = 0;
  private user: UserModel = {
    userId: 0,
    email: '',
    username: '',
    admin: false
  };
  reviewGroup:FormGroup = new FormGroup({
    text: new FormControl("", Validators.required)
  });
  movieTitle:string = this.imdbAPI.movieTitle;

  ngOnInit(): void {
    // This is how we find the userId of who is logged in.
    
  }

  createReview(revGroup:FormGroup)
  { 
    console.log(this.user);
    if (revGroup.valid) 
    {
      
      let review:Review = {
        userId: this.user.userId,
        text: revGroup.get("text")?.value,
        rating: this.currentRate,
        imdbId: this.imdbAPI.movieId,
        username: this.user.username
      }
      console.log(review);
      this.webAPI.createReview(review).subscribe(
        (response) => {
          console.log(response);
          this.router.navigateByUrl('/reviewlist');
        })
    }
  }

}
