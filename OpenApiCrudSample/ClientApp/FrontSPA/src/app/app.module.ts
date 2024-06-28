import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import {AppComponent} from './app.component';
import {ApiModule} from './api/api.module';
import {environment} from '../env/environment';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ApiModule.forRoot({ rootUrl : environment.apiServiceUrl})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
