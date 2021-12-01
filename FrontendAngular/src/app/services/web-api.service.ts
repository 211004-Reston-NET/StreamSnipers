import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WebAPIService {
  private endpoint:string = 'https://stream-snipers-backend.azurewebsites.net/api';
  constructor(private http:HttpClient) 
  {
  }

  ////////////// User //////////////
  LoginUser(p_email:string, p_password:string)
  {
    return this.http.get<any>(`${this.endpoint}/user/login/${p_email}/${p_password}`);
  }

  GetUserById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/user/${p_id}`);
  }

  
  ////////////// Review //////////////
  GetReviewById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/review/${p_id}`);
  }

  GetReviewByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/review/user/${p_userId}`);
  }


  ////////////// Recommendation //////////////
  GetRecommendationById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/recommendation/${p_id}`);
  }

  GetRecommendationByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/recommendation/user/${p_userId}`);
  } 


  ////////////// Previous Search //////////////
  GetPreviousSearchById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/previousSearch/${p_id}`);
  }

  GetPreviousSearchByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/previousSearch/user/${p_userId}`);
  }


  ////////////// Favorite List //////////////
  GetFavoriteListById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/favoriteList/${p_id}`);
  }

  GetFavoriteListByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/favoriteList/user/${p_userId}`);
  }

}
