import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { TestAPIService } from '../services/test-api.service';

@Component({
  selector: 'app-new-component',
  templateUrl: './User.component.html',
  styleUrls: ['./User.component.css']
})
export class UserComponent implements OnInit {

  listOfUser:User[] = [];

  constructor(private ssAPI:TestAPIService, private router:Router)
  {
    ssAPI.getAllUser().subscribe((response) => {
      this.listOfUser = response;
    });
  }

  ngOnInit(): void {
  }


  goToFavorite()
  {
    this.router.navigate(["/favorite"])
  }
}
