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

  getUserById(p_id:number)
  {
    return this.http.get<any>(`${this.endpoint}/user/${p_id}`);
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

  getFavoriteListByUserId(p_userId:number)
  {
    return this.http.get<any>(`${this.endpoint}/favoriteList/user/${p_userId}`);
  }

}
