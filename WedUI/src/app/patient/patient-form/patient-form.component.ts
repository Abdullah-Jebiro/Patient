import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientService } from 'src/app/services/patient.service';
import { IPatient } from '../Models/IPatient';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-patient-form',
  templateUrl: './patient-form.component.html',
  styleUrls: ['./patient-form.component.css']
})
export class PatientFormComponent implements OnInit, OnDestroy {

  private subs = new SubSink();

  patient!: IPatient;
  patientForm!: FormGroup;


  constructor(
    private formBuilder: FormBuilder,
    private patientService: PatientService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.initializeForm();
  }

  ngOnInit(): void {
    const itemId = this.route.snapshot.params['id'];
    if (itemId) {
      this.subs.sink = this.patientService.getPatientById(itemId).subscribe({
        next: (result) => {
          this.initializeForm(result);
        },
        error: (error) => {
          console.error('Error fetching patient:', error);
        }
      });
    } else {
      this.initializeForm();
    }
  }

  private initializeForm(patientData?: IPatient): void {
    this.patientForm = this.formBuilder.group({
      Id: [patientData?.id || null],
      Name: [patientData?.name || null, [Validators.required, Validators.maxLength(100)]],
      FileNo: [patientData?.fileNo || null, [Validators.required, Validators.min(1)]],
      CitizenId: [patientData?.citizenId || null, [Validators.required, Validators.maxLength(20)]],
      BirthDate: [patientData?.birthDate || null, [Validators.required]],
      Gender: [patientData?.gender, [Validators.required, Validators.min(0), Validators.max(1)]],
      Nationality: [patientData?.nationality || null, [Validators.required, Validators.maxLength(50)]],
      PhoneNumber: [patientData?.phoneNumber || null, [Validators.required, Validators.maxLength(15), Validators.pattern(/^[^a-zA-Z]*$/)]],
      Email: [patientData?.email || null, [Validators.required, Validators.email]],
      Country: [patientData?.country || null, [Validators.required, Validators.maxLength(50)]],
      City: [patientData?.city || null, [Validators.required, Validators.maxLength(50)]],
      Street: [patientData?.street || null, [Validators.required, Validators.maxLength(100)]],
      Address1: [patientData?.address1 || null, [Validators.required, Validators.maxLength(100)]],
      Address2: [patientData?.address2 || null, [Validators.maxLength(100)]],
      ContactPerson: [patientData?.contactPerson || null, [Validators.required, Validators.maxLength(100)]],
      ContactRelation: [patientData?.contactRelation || null, [Validators.required, Validators.maxLength(50)]],
      ContactPhone: [patientData?.contactPhone || null, [Validators.required, Validators.maxLength(15), Validators.pattern(/^[^a-zA-Z]*$/)]],
      FirstVisitDate: [patientData?.firstVisitDate || null, [Validators.required]],
    });
  }
  


  onSubmit(): void {
    if (this.patientForm.valid) {
      const formData = this.patientForm.value;

      if (formData.Id) {
        // Update existing patient
        this.patientService.updatePatient(formData).subscribe(() => {
          this.router.navigate(['/patients']);
        });
      } else {
        // Add new patient
        this.patientService.addPatient(formData).subscribe(() => {
        });
      }
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }


}