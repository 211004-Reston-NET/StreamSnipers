import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ImdbService } from '../services/imdb.service';
import { WebAPIService } from '../services/web-api.service';

@Component({
  selector: 'app-list-recommend',
  templateUrl: './list-recommend.component.html',
  styleUrls: ['./list-recommend.component.css']
})
export class ListRecommendComponent implements OnInit {

  constructor(private imdbAPI: ImdbService, private webAPI: WebAPIService, private router: Router) { 
  }

  @Input()
  id: string = '';

  color:string = '';
  btnColor:string = '';
  textColor:string = '';
  movieTitle: string = '';
  moviePoster: string = '';
  movieSimilar = [];

  ngOnInit(): void {
    this.randomColor()
    this.imdbAPI.imdbMovieSearch(this.id).subscribe(
      (response) => {
        console.log(response);
        this.moviePoster = response.image
        this.movieTitle = response.fullTitle
        this.movieSimilar = response.similars
        console.log(this.movieSimilar);
      }
    )
  }

  goToHome()
  {
    console.log("hit");
    this.imdbAPI.movieTitle = this.movieTitle;
    this.router.navigateByUrl("home");
  }


  randomColor()
  {
    let random = Math.floor(Math.random() * (7 - 1 + 1) + 1);
    switch (random) {
      case 1:
        this.color = 'border-primary';
        this.btnColor = 'btn-primary';
        this.textColor = 'text-primary';
        break;

      case 2:
        this.color = 'border-secondary';
        this.btnColor = 'btn-secondary';
        this.textColor = 'text-secondary';
        break;

      case 3:
        this.color = 'border-success';
        this.btnColor = 'btn-success';
        this.textColor = 'text-success';
        break;

      case 4:
        this.color = 'border-danger';
        this.btnColor = 'btn-danger';
        this.textColor = 'text-danger';
        break;

      case 5:
        this.color = 'border-warning';
        this.btnColor = 'btn-warning';
        this.textColor = 'text-warning';
        break;

      case 6:
        this.color = 'border-info';
        this.btnColor = 'btn-info';
        this.textColor = 'text-info';
        break;

      case 7:
        this.color = 'border-light';
        this.btnColor = 'btn-light';
        this.textColor = 'text-light';
        break;

      default:
        break;
    }
  }

}
