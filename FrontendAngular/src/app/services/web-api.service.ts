import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { firstValueFrom, Observable } from 'rxjs';
import { FavoriteList } from '../models/favoritelist';
import { Review } from '../models/review';
import { User } from '@auth0/auth0-spa-js';
import { UserModel } from '../models/user';

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
    let user:UserModel = {
      userId: 0,
      email: '',
      username: '',
      admin: false
    };
    this.auth0.user$.subscribe((user) => {
      if (user) {
        this.getUserByEmail(user.email).subscribe((userFound) => {
          user = userFound;
          return user;
        });
      }
    });
    return user;
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

  getUserByEmail(p_email:string|undefined|null)
  {
    return this.http.get<User>(`${this.endpoint}/user/userid/${p_email}`);
  }



  ////////////// Review //////////////
  getAllReviewByImdbId(p_imdbId:string|undefined)
  {
    return this.http.get<Review>(`${this.endpoint}/review/imdb/${p_imdbId}`);
  }

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

    let userFound: UserModel;
    userFound = await (await firstValueFrom(this.http.get<UserModel>(`${endpoint}/user/userid/${user?.email}`)));
    
    let favoriteList: FavoriteList = await firstValueFrom(this.http.get<FavoriteList>(`${endpoint}/favoriteList/user/${userFound.userId}`));
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
