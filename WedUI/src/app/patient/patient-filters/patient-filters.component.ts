import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPatientSearchFilters } from '../Models/IPatientSearchFilters';
import { ActivatedRoute, Router } from '@angular/router';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-patient-filters',
  templateUrl: './patient-filters.component.html',
  styleUrls: ['./patient-filters.component.css'],
})
export class PatientFiltersComponent {
  @Output() searchFilters = new EventEmitter<IPatientSearchFilters>();
  searchForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.searchForm = this.fb.group({
      name: [this.route.snapshot.queryParamMap.get('name') || null],
      fileNo: [this.route.snapshot.queryParamMap.get('fileNo') || null],
      phoneNumber: [this.route.snapshot.queryParamMap.get('phoneNumber') || null]
    });
    
    
  }

  searchPatients() {
    if (this.searchForm.valid) {
      const filters: IPatientSearchFilters = this.searchForm.value;
      this.searchFilters.emit(filters);

      // Update the URL with query parameters
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: filters,
        queryParamsHandling: 'merge',
      });
    }
  }
}
