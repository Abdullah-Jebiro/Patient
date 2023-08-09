import { Component, OnInit, OnDestroy } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';
import { SubSink } from 'subsink';
import { FormGroup } from '@angular/forms';
import { IPatientSearchFilters } from '../Models/IPatientSearchFilters';
import { IPatient } from '../Models/IPatient';


@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit, OnDestroy {
  private subs = new SubSink();
  totalPages!: number;
  currentPage: number = 1;
  PageSize: number = 2;
  totalItems!: number;
  patients: IPatient[] = [];
  searchForm!: FormGroup;

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.loadPatients();
  }

  pageChanged(page: number): void {
    this.currentPage = page;
    this.loadPatients();
  }

  searchPatients(filters: IPatientSearchFilters) {
    this.currentPage = 1;
    this.searchForm.patchValue(filters);
    this.loadPatients();
  }

  deletePatient(patientId: string) {
    console.log(patientId);
    this.subs.sink = this.patientService.deletePatient(patientId).subscribe({
      next: () => {
        const index = this.patients.findIndex(patient => patient.id == patientId);
        this.patients.splice(index, 1);
      }
    });
  }

  private loadPatients(): void {
  
    
    const name = this.searchForm?.get('name')?.value;
    const fileNo = this.searchForm?.get('fileNo')?.value;
    const phoneNumber = this.searchForm?.get('phoneNumber')?.value;

    this.subs.sink = this.patientService.getPatients(
      this.currentPage,
      this.PageSize,
      name,
      fileNo,
      phoneNumber
    ).subscribe({
      next: (result) => {
        this.patients = result.body!;
        const paginationData = JSON.parse(result.headers.get('x-pagination')!);
        this.totalItems = paginationData.TotalItemCount;
        this.currentPage = paginationData.CurrentPage;
      }
    });
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
