import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { FavoriteButtonComponent } from './favorite-button/favorite-button/favorite-button.component';
import { FavoriteButtonModule } from './favorite-button/favorite-button/favorite-button.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    FavoriteButtonModule,
    FavoriteButtonComponent
  ],
  declarations: [HomeComponent, FavoriteButtonComponent],
  exports: [HomeComponent]
})
export class HomeComponentModule { }