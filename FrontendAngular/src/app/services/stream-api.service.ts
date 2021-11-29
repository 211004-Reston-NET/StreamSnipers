import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StreamAPIService {
  API_KEY = '30de0fe045mshea7ef71956293e1p19e3acjsne10222692e6d';
  constructor(private http:HttpClient) { }
  private endpoint:string = 'https://streaming-availability.p.rapidapi.com/get/basic?country=us&output_language=en';


  // imdbId parameter:  should be the imdbid that we recieve from imdbMovieSearch(),
  // in order to find the exact same item that was found earlier.
  // ex: tt0126029
  streamingAvailability(imdbId:string)
  {
    return this.http.get(`${this.endpoint}&imdb_id=${imdbId}&rapidapi-key=${this.API_KEY}`)
  }
}
