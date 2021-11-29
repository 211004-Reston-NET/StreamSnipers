import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImdbService {

  constructor(private http:HttpClient) { }
  private endpoint:string = 'https://imdb-api.com/api/search/k_shxfmft9/';

  imdbMovieSearch(search:string)
  {
    return this.http.get(this.endpoint+search)
  }
}
