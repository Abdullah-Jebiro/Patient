import {
  Component,
  EventEmitter,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPatientSearchFilters } from '../Models/IPatientSearchFilters';
import { ActivatedRoute, Router } from '@angular/router';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-patient-filters',
  templateUrl: './patient-filters.component.html',
  styleUrls: ['./patient-filters.component.css'],
})
export class PatientFiltersComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  @Output() searchFilters = new EventEmitter<IPatientSearchFilters>();
  searchForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.searchForm = this.fb.group({
      name: [this.route.snapshot.queryParamMap.get('name') || undefined, [Validators.min(1)]],
      fileNo: [this.route.snapshot.queryParamMap.get('fileNo') || undefined],
      phoneNumber: [
        this.route.snapshot.queryParamMap.get('phoneNumber') || undefined, [Validators.maxLength(15), Validators.pattern(/^[^a-zA-Z]*$/)]]
    });
  }

  ngOnInit(): void {
    this.subs.sink = this.searchForm.valueChanges.subscribe(() =>
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: this.searchForm.value,
        queryParamsHandling: 'merge',
      })
    );
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
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
