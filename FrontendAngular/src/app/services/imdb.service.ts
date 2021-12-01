import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ImdbIdSearch } from '../models/imdb-id-search';

@Injectable({
  providedIn: 'root'
})
export class ImdbService {

  constructor(private http:HttpClient) { }
  private endpoint:string = 'https://imdb-api.com/api';
  private key:string = 'k_shxfmft9';

  // search parameter: should be the string from the search bar form at the top of the page.
  // will find the imdbId (ex: tt0126029) in order to be used in imdbMovieSearch method 
  imdbIdSearch(search:string)
  {
    return this.http.get<ImdbIdSearch>(`${this.endpoint}/search/${this.key}/${search}/`)
  }

  imdbMovieSearch(search:string)
  {
    return this.http.get<any>(`${this.endpoint}/title/${this.key}/${search}`)
  }

}
