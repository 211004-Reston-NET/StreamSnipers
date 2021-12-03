import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ImdbService } from '../services/imdb.service';
import { WebAPIService } from '../services/web-api.service';

@Component({
  selector: 'app-favorite-item',
  templateUrl: './favorite-item.component.html',
  styleUrls: ['./favorite-item.component.css']
})
export class FavoriteItemComponent implements OnInit {
  
  constructor(private imdbAPI: ImdbService, private webAPI: WebAPIService, private router: Router)
  {

  }
  @Input()
  favoriteListId: number = 0;

  @Input()
  imdbId: string = '';

  movieTitle: string = '';
  moviePoster: string = '';
  ngOnInit(): void 
  {
    this.imdbAPI.imdbMovieSearch(this.imdbId).subscribe(
      (response) => {
        console.log(response);
        this.moviePoster = response.image
        this.movieTitle = response.fullTitle
      }
    )
  }
  deleteFavorite(p_id: number) {
    this.webAPI.deleteFavorite(p_id).subscribe(
      (response) => {
        window.location.reload();
      }
    )
  }
  goToHome()
  {
    console.log("hit");
    this.imdbAPI.movieTitle = this.movieTitle;
    this.router.navigateByUrl("home");
  }

}
