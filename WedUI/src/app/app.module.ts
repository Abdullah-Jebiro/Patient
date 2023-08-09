import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: 'patient',
        loadChildren: () => import('./patient/patient.module').then((P) => P.PatientModule)
      },
      { path: '', redirectTo: 'patient', pathMatch: 'full' },
      { path: '**', redirectTo: 'patient', pathMatch: 'full' },
    ])],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
