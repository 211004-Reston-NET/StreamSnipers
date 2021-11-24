import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FavoriteList } from '../models/favoritelist';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})
export class TestAPIService {

  private endpoint:string = 'https://stream-snipers-backend.azurewebsites.net/api/';
  constructor(private http:HttpClient) 
  { 
  }

  // This will give a list of All Users from WebAPI
  getAllUser() : Observable<User[]>
  {
    return this.http.get<User[]>(this.endpoint+'user/all');
  }

  getFavoriteListById(p_id:number) : Observable<FavoriteList[]>
  {
    return this.http.get<FavoriteList[]>(this.endpoint+`favoriteList/${p_id}`)
  }

}
