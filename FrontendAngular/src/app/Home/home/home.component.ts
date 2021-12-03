import { DOCUMENT } from '@angular/common';
import { Component, OnInit, Input, Output, EventEmitter, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { FavoriteList } from 'src/app/models/favoritelist';
import { ImdbService } from 'src/app/services/imdb.service';
import { WebAPIService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  searchtext: string = '';
  imdbId: string = '';
  movePosterSrc: string = '';
  movieTitleSrc: string = '';
  movieReleaseDateSrc: string = '';
  movieRuntimeSrc: string = '';
  movieDescriptionSrc: string = '';
  movieAwardsSrc: string ='';
  favorite: FavoriteList = {
    favoriteListId: 0,
    userId: 0,
    imdbId: '',
    name: '',
    netflix: false,
    hulu: false,
    amazonVideo: false,
    hboMax: false,
    disneyPlus: false
  };
  @Input()                    
  selected: boolean = false;
  @Output() selectedChange = new EventEmitter<boolean>();




  constructor
  (
    public imdbAPI: ImdbService, 
    public auth0:AuthService, 
    @Inject(DOCUMENT) public document: Document, 
    public webAPI: WebAPIService, 
    private router: Router
  ) 
  {
    this.favorite.userId = this.webAPI.getId();
    this.searchtext = this.imdbAPI.movieTitle;
  }

  ngOnInit(): void {
    this.auth0.user$.subscribe(
      (profile) => 
      {
        if(profile)
        {
        // check if user is in db already
          this.webAPI.loginUser(profile.email).subscribe(
            (response) => 
            {
              if (!response)
              {
                // post new user here using profile.email 
              }
              else 
              {
                this.favorite.userId = response.userId;
              }
            }
          )
        }
      }
      );
    // runs the movie search if approaching from clicked favorite
    if (this.searchtext)
    {
      this.imdbSearch(this.searchtext);
    }
  }

  imdbSearch(search: string) {
    this.imdbAPI.imdbIdSearch(search).subscribe(
      (response) => {
        this.imdbId = response.results[0].id;
        if (this.imdbId) {
          this.imdbAPI.imdbMovieSearch(this.imdbId).subscribe(
            (res) => {
              // got the movie stuff here.
              this.movePosterSrc = res.image;
              this.movieTitleSrc = res.title;
              this.movieReleaseDateSrc = res.releaseDate;
              this.movieRuntimeSrc = res.runtimeStr;
              this.movieDescriptionSrc = res.plot;
              this.movieAwardsSrc = res.awards;
              this.imdbAPI.movieTitle = res.title;
                // changing favorite in case they click add to favorite
              this.favorite.name = this.movieTitleSrc;
              this.favorite.imdbId = this.imdbId;
            }
          )
        }
      })
  }

  addToFavorites()
  {
    console.log(this.favorite);
    this.webAPI.createFavorite(this.favorite).subscribe(
      (response) => {
        console.log(response);
      });
  }

  goToReview() 
  {
    this.router.navigateByUrl("/review");
  }

  public toggleSelected() {
    this.selected = !this.selected;
    this.selectedChange.emit(this.selected);
  }
}
