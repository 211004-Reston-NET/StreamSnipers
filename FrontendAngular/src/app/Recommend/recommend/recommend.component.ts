import { Component, OnInit, Input } from '@angular/core';
import { Review } from '../../models/review';
import { UserModel } from '../../models/user';
import { ImdbService } from '../../services/imdb.service';
import { WebAPIService } from '../../services/web-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recommend',
  templateUrl: './recommend.component.html',
  styleUrls: ['./recommend.component.css']
})
export class RecommendComponent implements OnInit {

  movieTitle:string = this.imdbAPI.movieTitle;
  movieId: string = this.imdbAPI.movieId;
  moviePoster: string = '';
  movieSimilar:any = [];

  @Input()
  imdbId: string = '';

  constructor(private imdbAPI: ImdbService, private webAPI: WebAPIService, private router: Router) {
    this.imdbAPI.imdbMovieSearch(this.movieId).subscribe(
      (response) => {
        console.log(response);
        this.moviePoster = response.image
        this.movieTitle = response.fullTitle
        this.movieSimilar = this.movieSimilar.concat(response.similars)
        console.log(this.movieSimilar);
      }
    )
   }

  ngOnInit(): void {
  }

}
