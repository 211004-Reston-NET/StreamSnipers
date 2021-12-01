import { DOCUMENT } from '@angular/common';
import { Component, OnInit, Input, Output, EventEmitter, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
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
  @Input()                    
  selected: boolean = false;
  @Output() selectedChange = new EventEmitter<boolean>();




  constructor
  (
    public imdbAPI: ImdbService, 
    public auth0:AuthService, 
    @Inject(DOCUMENT) public document: Document, 
    public webAPI: WebAPIService          
  ) 
  {
  }

  ngOnInit(): void {
    this.auth0.user$.subscribe(
      (profile) => 
      {
        if(profile)
        {
          console.log(profile);
        // check if user is in db already
          this.webAPI.loginUser(profile.email).subscribe(
            (response) => 
            {
              if (!response)
              {
                // post new user here using profile.email 
              }
            }
          )
        }
      }
      );
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
            }
          )
        }
      })
  }

  public toggleSelected() {
    this.selected = !this.selected;
    this.selectedChange.emit(this.selected);
  }
}
