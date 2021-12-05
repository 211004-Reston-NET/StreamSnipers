import { HttpClient } from '@angular/common/http';
import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { FavoriteList } from '../../models/favoritelist';
import { WebAPIService } from '../../services/web-api.service';

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css']
})
export class FavoriteComponent implements OnChanges {

  listOfFavorites:FavoriteList[] = [];
  constructor(private webAPI: WebAPIService, private router: Router)
  {
    this.webAPI.getFavoriteListByUserId().then((response) => {
      console.log(response);
      this.listOfFavorites = this.listOfFavorites.concat(response);
      console.log(this.listOfFavorites);
    })
  }
  ngOnChanges(changes: SimpleChanges): void {
    
  }
  
}
