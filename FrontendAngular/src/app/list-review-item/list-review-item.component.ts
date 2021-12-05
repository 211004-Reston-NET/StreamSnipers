import { Component, Input, OnInit } from '@angular/core';
import { Review } from '../models/review';
import { ImdbService } from '../services/imdb.service';
import { WebAPIService } from '../services/web-api.service';

@Component({
  selector: 'app-list-review-item',
  templateUrl: './list-review-item.component.html',
  styleUrls: ['./list-review-item.component.css']
})
export class ListReviewItemComponent implements OnInit {

  constructor() {
    this.randomColor();
  }

  @Input()
  text:string = '';

  @Input()
  rating:number = 0;

  @Input()
  username:string = '';
  
  
  color: string = '';

  ngOnInit(): void {
  }

  randomColor() {
    let random = Math.floor(Math.random() * (7 - 1 + 1) + 1);
    switch (random) {
      case 1:
        this.color = 'bg-primary';
        break;

      case 2:
        this.color = 'bg-secondary';
        break;

      case 3:
        this.color = 'bg-success';
        break;

      case 4:
        this.color = 'bg-danger';
        break;

      case 5:
        this.color = 'bg-warning';
        break;

      case 6:
        this.color = 'bg-info';
        break;

      case 7:
        this.color = 'bg-light';
        break;

      default:
        break;
    }
  }
}
