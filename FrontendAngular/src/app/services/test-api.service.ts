import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FavoriteList } from '../models/favoritelist';


@Injectable({
  providedIn: 'root'
})
export class TestAPIService {

  private endpoint:string = 'https://stream-snipers-backend.azurewebsites.net/api/';
  constructor(private http:HttpClient) 
  { 
  }

  getAllFavoriteList() : Observable<FavoriteList[]>
  {
    return this.http.get<FavoriteList[]>(this.endpoint+`favoriteList/all`)
  }

  DeleteFavoriteListById(p_id:number) : Observable<FavoriteList[]>
  {
    return this.http.get<FavoriteList[]>(this.endpoint+`favoriteList/${p_id}`)
  }
}

