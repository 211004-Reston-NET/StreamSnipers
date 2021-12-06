import { Component, OnInit } from '@angular/core';
import { Review } from '../../models/review';
import { UserModel } from '../../models/user';
import { ImdbService } from '../../services/imdb.service';
import { WebAPIService } from '../../services/web-api.service';

@Component({
  selector: 'app-recommend',
  templateUrl: './recommend.component.html',
  styleUrls: ['./recommend.component.css']
})
export class RecommendComponent implements OnInit {
  listOfReview: Review[] = [];
  movieTitle:string = this.imdbAPI.movieTitle;
  movieId: string = this.imdbAPI.movieId;

  constructor(private imdbAPI: ImdbService, private webAPI: WebAPIService) {
    this.webAPI.getAllReviewByImdbId(this.movieId).subscribe(
      (response) => {
        
        this.listOfReview = this.listOfReview.concat(response);
        console.log(this.listOfReview);
      });
   }

  ngOnInit(): void {
  }

}
