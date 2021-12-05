import { Component, OnInit } from '@angular/core';
import { Review } from '../models/review';
import { UserModel } from '../models/user';
import { ImdbService } from '../services/imdb.service';
import { WebAPIService } from '../services/web-api.service';

@Component({
  selector: 'app-list-review',
  templateUrl: './list-review.component.html',
  styleUrls: ['./list-review.component.css']
})
export class ListReviewComponent implements OnInit {
  listOfReview: Review[] = [];
  movieTitle:string = this.imdbAPI.movieTitle;
  movieId: string = this.imdbAPI.movieId;
  
  constructor(private imdbAPI: ImdbService, private webAPI: WebAPIService)
  {
    
    this.webAPI.getAllReviewByImdbId(this.movieId).subscribe(
      (response) => {
        
        this.listOfReview = this.listOfReview.concat(response);
        console.log(this.listOfReview);
      });
    
  }

  ngOnInit(): void 
  {
  }
}
