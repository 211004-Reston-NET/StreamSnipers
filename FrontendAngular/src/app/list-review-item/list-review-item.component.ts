import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Review } from '../models/review';
import { UserModel } from '../models/user';
import { ImdbService } from '../services/imdb.service';
import { WebAPIService } from '../services/web-api.service';

@Component({
  selector: 'app-list-review-item',
  templateUrl: './list-review-item.component.html',
  styleUrls: ['./list-review-item.component.css']
})
export class ListReviewItemComponent implements OnInit {

  constructor(private webAPI: WebAPIService, private route: ActivatedRoute, private router: Router)
  {
    // this allows us to reload page without erasing the data still stored on this.imdbAPI on the list-review.ts file.
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';

    this.randomColor();
    this.admin = this.webAPI.admin;
  }


  @Input()
  text:string = '';

  @Input()
  rating:number = 0;

  @Input()
  username:string = '';

  @Input()
  reviewId:number|undefined = 0;
  
  admin: boolean = false;
  
  color: string = '';

  ngOnInit(): void {
    
  }
  DeleteReview()
  {
    this.webAPI.deleteReview(this.reviewId).subscribe(
      (response) => {
        this.router.navigateByUrl('/reviewlist');
      })
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
