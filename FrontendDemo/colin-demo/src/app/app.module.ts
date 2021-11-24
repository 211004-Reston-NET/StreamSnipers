import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { UserComponent } from './User/User.component';
import { FavoriteComponent } from './favorite/favorite.component';
import { RouterModule } from '@angular/router';

/*
  like csproj in C#, app.module.ts defines all of your dependencies that your angular app wil use.
*/

@NgModule({
  // reference to our components
  declarations: [
    AppComponent,
    UserComponent,
    FavoriteComponent
  ],
  // hold references to modules (packages)
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'user', component:UserComponent},
      {path: 'favorite', component:FavoriteComponent},
      {path: '*', component:UserComponent}
    ])
  ],
  // reference to services.
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
