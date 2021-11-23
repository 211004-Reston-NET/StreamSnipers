import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './Home/home/home.component';
import { FavoriteComponent } from './Favorite/favorite/favorite.component';
import { LoginComponent } from './Login/login/login.component';
import { ReviewComponent } from './review/review/review.component';
import { SearchComponent } from './search/search/search.component';
import { RecommendComponent } from './Recommend/recommend/recommend.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FavoriteComponent,
    LoginComponent,
    ReviewComponent,
    SearchComponent,
    RecommendComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
