import { Component, OnInit, OnDestroy } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';
import { SubSink } from 'subsink';
import { IPatientSearchFilters } from '../Models/IPatientSearchFilters';
import { IPatient } from '../Models/IPatient';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css'],
})
export class PatientListComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  patients: IPatient[] = [];
  patientSearchFilters!: IPatientSearchFilters;
  currentPage = 1;
  PageSize = 3;
  totalItems = 0;
  isModalOpen = false;

  constructor(
    private patientService: PatientService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.checkQueryParams();
    this.loadPatients();
  }



  /**
   * Checks query parameters for modal display.
   */
  checkQueryParams(): void {
    this.subs.sink = this.route.queryParamMap.subscribe((queryParams) => {
      const shouldOpenModal =
        queryParams.has('edit') || queryParams.get('add') === 'true';
      if (shouldOpenModal) {
        this.openModal();
      }

      // Read and set query parameters on the search form
      const name = queryParams.get('name') || undefined;
      const fileNo = queryParams.get('fileNo') || undefined;
      const phoneNumber = queryParams.get('phoneNumber') || undefined;
      this.currentPage = Number(queryParams.get('currentPage')) || 1;

      this.patientSearchFilters = {
        name: name,
        fileNo: Number(fileNo),
        phoneNumber: phoneNumber
      };

    });
  }


  /** 
   * @param page The new page number.
   */
  pageChanged(page: number): void {
    this.currentPage = page;
    this.loadPatients();
  }

  /**
   * Searches for patients based on filters.
   * @param filters The search filters.
   */
  searchPatients(filters: IPatientSearchFilters) {
    this.currentPage = 1;
    this.patientSearchFilters = filters;
    this.loadPatients();
  }

  /**
   * Deletes a patient.
   * @param patientId The ID of the patient to delete.
   */
  deletePatient(patientId: string) {
    this.subs.sink = this.patientService.deletePatient(patientId).subscribe({
      next: () => {
        this.removeDeletedPatient(patientId);
        //this.loadPatients(); If you want to update the items total
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  /**
   * Loads patients based on current filters and pagination.
   */
  loadPatients(): void {
    this.subs.sink = this.patientService
      .getPatients(
        this.currentPage,
        this.PageSize,
        this.patientSearchFilters
      )
      .subscribe({
        next: (result) => {
          this.patients = result.body ?? [];
          const paginationData = JSON.parse(
            result.headers.get('x-pagination')!
          );
          this.totalItems = paginationData.TotalItemCount;
          this.currentPage = paginationData.CurrentPage;
        },
        error: (error) => {
          console.error(error);
          this.patients = [];
        },
      });
  }

  /**
   * Opens the patient modal.
   */
  openModal(): void {
    this.isModalOpen = true;
  }

  /**
   * Closes the patient modal and reloads patients.
   */
  closeModal(): void {
    const queryParams = this.route.snapshot.queryParams;

    // Remove specific query parameters related to add and edit
    const updatedQueryParams = { ...queryParams };
    delete updatedQueryParams['add'];
    delete updatedQueryParams['edit'];
  
    // Navigate to the same route with the updated query parameters
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: updatedQueryParams,
    });
    

    this.isModalOpen = false;
    this.loadPatients();
}

  /**
   * Removes a deleted patient from the list.
   * @param patientId The ID of the deleted patient.
   */
  removeDeletedPatient(patientId: string): void {
    const index = this.patients.findIndex((patient) => patient.id == patientId);
    if (index !== -1) {
      this.patients.splice(index, 1);
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
