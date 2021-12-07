import { HttpEvent, HttpHandler, HttpRequest, HttpInterceptor } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CorsInterceptorService implements HttpInterceptor {

  constructor()
  {

  }
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = request.clone({
      setHeaders: { 'content-type': 'application/json',
                    'Access-Control-Allow-Origin': '*',
                    'Access-Control-Allow-Methods': 'OPTIONS, HEAD, GET, POST, PUT, PATCH, DELETE',
                    'Access-Control-Allow-Headers': 'X-Requested-With, Content-Type, Origin, Authorization, Accept, Client-Security-Token, Accept-Encoding, X-Auth-Token, content-type',
    }
    })
    return next.handle(request);
  }

}
