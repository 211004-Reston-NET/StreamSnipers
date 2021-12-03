import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { firstValueFrom, Observable } from 'rxjs';
import { FavoriteList } from '../models/favoritelist';
import { Review } from '../models/review';
import { User } from '@auth0/auth0-spa-js';

@Injectable({
  providedIn: 'root'
})
export class WebAPIService {
  private endpoint:string = 'https://stream-snipers-backend.azurewebsites.net/api';
  constructor(private http:HttpClient, private auth0:AuthService) 
  {
  }

  //// Call this function to get the userId of the user logged in. ////
  getId()
  {
    let id:number = 0;
    this.auth0.user$.subscribe((user) => {
      if (user) {
        this.getUserIdByEmail(user.email).subscribe((userId) => {
          id = userId;
          return id;
        });
      }
    });
    return id;
  }

  ////////////// User //////////////
  loginUser(p_email:string|undefined)
  {
    if(p_email)
    {
      return this.http.get<any>(`${this.endpoint}/user/login/${p_email}`);    
    }
    else
    {
      return this.http.get<any>(`${this.endpoint}/user/login/`); 
    }
    
  }

  getUserById(p_id:number|undefined)
  {
    return this.http.get<any>(`${this.endpoint}/user/${p_id}`);
  }

  getUserIdByEmail(p_email:string|undefined|null)
  {
    return this.http.get<number>(`${this.endpoint}/user/userid/${p_email}`);
  }



  ////////////// Review //////////////
  getReviewById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/review/${p_id}`);
  }

  getReviewByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/review/user/${p_userId}`);
  }

  createReview(review:Review)
  {
    return this.http.post<Review>(`${this.endpoint}/review/add`, review);
  }


  ////////////// Recommendation //////////////
  getRecommendationById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/recommendation/${p_id}`);
  }

  getRecommendationByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/recommendation/user/${p_userId}`);
  } 


  ////////////// Previous Search //////////////
  getPreviousSearchById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/previousSearch/${p_id}`);
  }

  getPreviousSearchByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/previousSearch/user/${p_userId}`);
  }


  ////////////// Favorite List //////////////
  getFavoriteListById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/favoriteList/${p_id}`);
  }

  async getFavoriteListByUserId()
  {
    let endpoint = 'https://stream-snipers-backend.azurewebsites.net/api';

    let user: User | null | undefined;
    user = await firstValueFrom(this.auth0.user$);

    let userId: number;
    userId = await firstValueFrom(this.http.get<number>(`${endpoint}/user/userid/${user?.email}`));

    let favoriteList: FavoriteList = await firstValueFrom(this.http.get<FavoriteList>(`${endpoint}/favoriteList/user/${userId}`));
    return favoriteList;
  }

  getAllFavoriteList()
  {
    return this.http.get<any>(`${this.endpoint}/favoriteList/all`);
  }

  createFavorite(p_favorite: FavoriteList) 
  {
    return this.http.post<FavoriteList>(`${this.endpoint}/favoriteList/add`, p_favorite);
  }

  deleteFavorite(p_id:number)
  {
    return this.http.delete<any>(`${this.endpoint}/favoriteList/${p_id}`);
  }
}
