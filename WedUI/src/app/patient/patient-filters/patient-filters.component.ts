import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPatientSearchFilters } from '../Models/IPatientSearchFilters';

@Component({
  selector: 'app-patient-filters',
  templateUrl: './patient-filters.component.html',
  styleUrls: ['./patient-filters.component.css']
})
export class PatientFiltersComponent {
  @Output() searchFilters = new EventEmitter<IPatientSearchFilters>(); 
  searchForm: FormGroup;
  
  constructor(private fb: FormBuilder) {
    this.searchForm = this.fb.group({
      name: ['', Validators.maxLength(100)],
      fileNo: [null, Validators.min(0)],
      phoneNumber: ['', Validators.pattern(/^[^a-zA-Z]*$/)] 

    
    });
  }
  searchPatients() {
    if (this.searchForm.valid) {
      const filters: IPatientSearchFilters = this.searchForm.value;
      this.searchFilters.emit(filters);
    }
  }
}