import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ImdbService {

  constructor(private http:HttpClient) { }
  private endpoint:string = 'https://imdb-api.com/api/search/k_shxfmft9/';

  // search parameter: should be the string from the search bar form at the top of the page.
  imdbMovieSearch(search:string)
  {
    return this.http.get(this.endpoint+search)
  }
}
