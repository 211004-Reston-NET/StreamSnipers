import { Component, OnInit } from '@angular/core';
import { FavoriteList } from 'src/app/models/favoritelist';
import { WebAPIService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-pricing',
  templateUrl: './pricing.component.html',
  styleUrls: ['./pricing.component.css']
})
export class PricingComponent implements OnInit {
  totalFavorites = {
    netflix: 0,
    hulu: 0,
    disneyPlus: 0,
    hboMax: 0,
    amazonVideo: 0
  }
  listOfFavorites:FavoriteList[] = [];


  constructor(private webAPI: WebAPIService) 
  { 
    this.webAPI.getFavoriteListByUserId().then((response) => {
      console.log(response);
      this.listOfFavorites = this.listOfFavorites.concat(response);
      // console.log(this.listOfFavorites);
      this.listOfFavorites.forEach(element => {
        if (element.netflix)
        {
          this.totalFavorites.netflix++;
        }
        if (element.hulu) {
          this.totalFavorites.hulu++;
        }
        if (element.disneyPlus) {
          this.totalFavorites.disneyPlus++;
        }
        if (element.hboMax) {
          this.totalFavorites.hboMax++;
        }
        if (element.amazonVideo) {
          this.totalFavorites.amazonVideo++;
        }
      });
      console.log(this.totalFavorites);
    })
  }

  ngOnInit(): void {
  }

}
