import { Component, OnInit, Output } from '@angular/core';
import { FavoriteList } from '../../models/favoritelist';
import { TestAPIService } from '../../services/test-api.service';

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css']
})
export class FavoriteComponent implements OnInit {

  listOfUser:FavoriteList[] = [];

  constructor(private ssAPI:WebAPIService) 
  {
    ssAPI.getAllFavoriteList().subscribe((response) => {
      this.listOfUser = response;
    });

    // ssAPI.DeleteFavoriteListById(id).subscribe((response) => {
    //   this.listOfUser = response;
    // });
  }

  ngOnInit(): void {
  }

}
