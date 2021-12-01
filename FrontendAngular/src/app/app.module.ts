import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './Home/home/home.component';
import { FavoriteComponent } from './Favorite/favorite/favorite.component';
import { LoginComponent } from './Login/login/login.component';
import { ReviewComponent } from './Review/review/review.component';
import { SearchComponent } from './Search/search/search.component';
import { RecommendComponent } from './Recommend/recommend/recommend.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from '@auth0/auth0-angular';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { PricingComponent } from './pricing/pricing/pricing.component';
import { FeaturesComponent } from './features/features/features.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FavoriteComponent,
    LoginComponent,
    ReviewComponent,
    SearchComponent,
    RecommendComponent,
    NavBarComponent,
    PricingComponent,
    FeaturesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AuthModule.forRoot({
      clientId:"ylc2Bk1RtqVm7MLmdYotdddAeRSbrUc5",
      domain:"dev-3g3556dl.us.auth0.com"
    }),
    RouterModule.forRoot([
      {path: "search", component:SearchComponent},
      {path: "pricing", component:PricingComponent},
      {path: "features", component:FeaturesComponent},
      {path: "**", component:HomeComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
