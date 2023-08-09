import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { PatientListComponent } from './patient-list/patient-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { PatientFiltersComponent } from './patient-filters/patient-filters.component';
import { PatientFormComponent } from './patient-form/patient-form.component';


@NgModule({
  declarations: [
    PatientListComponent,
    PatientFiltersComponent,
    PatientFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    NgxPaginationModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: PatientListComponent },
      { path: '**', redirectTo: '', pathMatch: 'full' }
    ])
  ]
})
export class PatientModule { }
