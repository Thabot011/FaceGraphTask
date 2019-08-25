import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthComponent } from './auth/auth.component';
import { HomeComponent } from './home/home.component';
import { AuthService } from './auth.service';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './auth.guard';
import { AuthInterceptor } from './auth-interceptor';
import { ImageComponent } from './image/image.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import {
  MatTableModule,
  MatDialogModule,
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule
} from '@angular/material';
import { ImageService } from './Api/services';
import { ApiModule } from './Api/api.module';



export function getToken(): string {
  return localStorage.getItem('token');
}


@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    HomeComponent,
    ImageComponent,
  ],
  imports: [
    ApiModule.forRoot({ rootUrl: 'http://localhost:5001' }),
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MatTableModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: getToken
      }
    })
  ],
  providers: [
    AuthService,
    JwtHelperService,
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    ImageService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
