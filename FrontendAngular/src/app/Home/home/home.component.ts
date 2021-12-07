import { DOCUMENT } from '@angular/common';
import { ClassGetter } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit, Input, Output, EventEmitter, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { AddByEmail } from 'src/app/models/addUserEmail';
import { FavoriteList } from 'src/app/models/favoritelist';
import { UserModel } from 'src/app/models/user';
import { ImdbService } from 'src/app/services/imdb.service';
import { StreamAPIService } from 'src/app/services/stream-api.service';
import { WebAPIService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  searchtext: string = '';
  userId: number = 0;

  @Output()
  isFavorite: boolean = false;

StreamingInfo = {
  netflix: false,
  netflixName: "Netflix",
  netflixLink: "",
  hbo: false,
  hboName: "Hbo",
  hboLink: "",
  hulu: false,
  huluName: "Hulu",
  huluLink: "",
  disneyplus: false,
  disneyplusName: "Disney Plus",
  disneyplusLink: "",
  amazonprime: false,
  amazonprimeName: "Amazon Prime",
  amazonprimeLink: ""

}

  

  imdbId: string = '';
  movePosterSrc: string = '';
  movieTitleSrc: string = '';
  movieReleaseDateSrc: string = '';
  movieRuntimeSrc: string = '';
  movieDescriptionSrc: string = '';
  movieAwardsSrc: string = '';
  newFavorite: FavoriteList = {
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
  favoriteList: FavoriteList[] = [];
  @Input()
  selected: boolean = false;
  @Output() selectedChange = new EventEmitter<boolean>();




  constructor
    (
      public imdbAPI: ImdbService,
      public auth0: AuthService,
      @Inject(DOCUMENT) public document: Document,
      public webAPI: WebAPIService,
      private router: Router,
      public streamAPI: StreamAPIService
    ) {
    this.webAPI.getUser()
    this.searchtext = this.imdbAPI.movieTitle;

    this.auth0.user$.subscribe(
      (profile) => {
        if (profile) {
          console.log(profile);
          this.webAPI.loginUser(profile.email).subscribe(
            (response) => {
              console.log('login');
              console.log(response);
              if (!response) {
                var addByEmail: AddByEmail = {
                  email: profile.email?.toString()!,
                  username: profile.nickname
                };
                this.webAPI.addUserByEmail(addByEmail).subscribe(
                  (response) => {
                    console.log(response);
                    this.newFavorite.userId = response.userId;
                  }
                )
              }
              this.newFavorite.userId = response.userId;
            }
          );
        }
      }
    );
  }

  ngOnInit(): void {
    // check db to see if movie is favorited already
    this.webAPI.getFavoriteListByUserId().then((response) => {
      this.favoriteList = this.favoriteList.concat(response);
    });
    // runs the movie search if approaching from clicked favorite
    if (this.searchtext) {
      this.imdbSearch(this.searchtext);
    }

    
}

  imdbSearch(search: string) {
    this.imdbAPI.imdbIdSearch(search).subscribe(
      (response) => {
        this.imdbId = response.results[0].id;
        this.favoriteList.forEach(element => {
          if (element.imdbId == response.results[0].id) {
            this.isFavorite = true;
          }
          else
          {
            this.isFavorite = false;
          }
        });
        if (this.imdbId) {
          this.imdbAPI.imdbMovieSearch(this.imdbId).subscribe(
            (res) => {
              console.log(res);
              // got the movie stuff here.
              this.movePosterSrc = res.image;
              this.movieTitleSrc = res.title;
              this.movieReleaseDateSrc = res.releaseDate;
              this.movieRuntimeSrc = res.runtimeStr;
              this.movieDescriptionSrc = res.plot;
              this.movieAwardsSrc = res.awards;

              //save title and id to be used in other components
              this.imdbAPI.movieTitle = res.title;
              this.imdbAPI.movieId = this.imdbId;

              // changing favorite in case they click add to favorite
              this.newFavorite.name = this.movieTitleSrc;
              this.newFavorite.imdbId = this.imdbId;

              this.streamAPI.streamingAvailability(this.imdbId).subscribe(
                (result) => {
                  console.log(result);
                  console.log(result.streamingInfo);
                  // Netflix
                  if (result.streamingInfo.netflix)
                  {
                    this.StreamingInfo.netflix = true;
                    this.StreamingInfo.netflixLink = result.streamingInfo.netflix.us.link;
                    this.newFavorite.netflix = true;
                  }
                  else 
                  {
                    this.StreamingInfo.netflix = false;
                  }
                  // HBO Max
                  if (result.streamingInfo.hbo)
                  {
                    this.StreamingInfo.hbo = true;
                    this.StreamingInfo.hboLink = result.streamingInfo.hbo.us.link;
                    this.newFavorite.hboMax = true;
                  }
                  else 
                  {
                    this.StreamingInfo.hbo= false;
                  }
                  // Hulu
                  if (result.streamingInfo.hulu)
                  {
                    this.StreamingInfo.hulu = true;
                    this.StreamingInfo.huluLink = result.streamingInfo.hulu.us.link;
                    this.newFavorite.hulu = true;
                  }
                  else 
                  {
                    this.StreamingInfo.hulu = false;
                  }
                  // Disney+
                  if (result.streamingInfo.disney)
                  {
                    this.StreamingInfo.disneyplus = true;
                    this.StreamingInfo.disneyplusLink = result.streamingInfo.disney.us.link;
                    this.newFavorite.disneyPlus = true;
                  }
                  else 
                  {
                    this.StreamingInfo.disneyplus = false;
                  }
                  if (result.streamingInfo.prime)
                  {
                    this.StreamingInfo.amazonprime = true;
                    this.StreamingInfo.amazonprimeLink = result.streamingInfo.prime.us.link;
                    this.newFavorite.amazonVideo = true;
                  }
                  else 
                  {
                    this.StreamingInfo.amazonprime = false;
                  }
                }
              )


            }
          )
        }
      })
  }

  addToFavorites() {
    this.webAPI.createFavorite(this.newFavorite).subscribe(
      (response) => {
        console.log(response);
        this.isFavorite = true;
      });
  }

  goToReview() {
    this.router.navigateByUrl("/review");
  }

  deleteFavorite() {
    let id:number|undefined = 0;
    this.favoriteList.forEach(element => {
      if (element.imdbId == this.imdbId) {
        id = element.favoriteListId;
      }
    });
    this.webAPI.deleteFavorite(id).subscribe(
      (response) => {
        this.isFavorite = false;
      }
    )
  }
  viewReviewList()
  {
    this.router.navigateByUrl("/reviewlist");
  }

  viewRecommendList()
  {
    this.router.navigateByUrl("/recommend");
  }

  public toggleSelected() {
    this.selected = !this.selected;
    this.selectedChange.emit(this.selected);
  }
}
