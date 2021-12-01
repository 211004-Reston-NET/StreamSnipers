import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ImdbService } from 'src/app/services/imdb.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  searchtext: string = '';
  imdbId: string = '';
  movePosterSrc: string = '';
  @Input()
  selected: boolean = false;
  @Output() selectedChange = new EventEmitter<boolean>();




  constructor(public imdbAPI: ImdbService) { }

  ngOnInit(): void {
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
