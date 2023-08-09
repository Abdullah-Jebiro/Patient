import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientService } from 'src/app/services/patient.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-patient-form',
  templateUrl: './patient-form.component.html',
  styleUrls: ['./patient-form.component.css']
})
export class PatientFormComponent implements OnInit, OnDestroy {
  
  @Output() closeModal: EventEmitter<void> = new EventEmitter<void>();
  private subs = new SubSink();
  patientForm!: FormGroup;
  isEditing: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private patientService: PatientService,
    private router: Router,
    private route: ActivatedRoute
  ) { }


  ngOnInit(): void {

    this.initializeForm();
    this.subs.sink = this.route.queryParamMap.subscribe((queryParams) => {
      const patientId = queryParams.get('edit');
      if (patientId) {
        this.isEditing = true;
        this.subs.sink = this.patientService.getPatientById(patientId).subscribe({
          next: (result) => {
            this.patientForm.patchValue(result);  
            console.log(this.patientForm.value);
                                
          },
          error: (error) => {
            console.error('Error fetching patient:', error);
          }
        });
      }
    });
  }


  private initializeForm(): void {
    this.patientForm = this.formBuilder.group({
      id: [null],
      name: [null, [Validators.required, Validators.maxLength(100)]],
      fileNo: [null, [Validators.required, Validators.min(1)]],
      citizenId: [null, [Validators.required, Validators.maxLength(20)]],
      birthDate: [null, [Validators.required]],
      gender: [null, [Validators.required, Validators.min(0), Validators.max(1)]],
      nationality: [null, [Validators.required, Validators.maxLength(50)]],
      phoneNumber: [null, [Validators.required, Validators.maxLength(15), Validators.pattern(/^[^a-zA-Z]*$/)]],
      email: [null, [Validators.required, Validators.email]],
      country: [null, [Validators.required, Validators.maxLength(50)]],
      city: [null, [Validators.required, Validators.maxLength(50)]],
      street: [null, [Validators.required, Validators.maxLength(100)]],
      address1: [null, [Validators.required, Validators.maxLength(100)]],
      address2: [null, [Validators.maxLength(100)]],
      contactPerson: [null, [Validators.required, Validators.maxLength(100)]],
      contactRelation: [null, [Validators.required, Validators.maxLength(50)]],
      contactPhone: [null, [Validators.required, Validators.maxLength(15), Validators.pattern(/^[^a-zA-Z]*$/)]],
      firstVisitDate: [null, [Validators.required]],
    });

    
  }

  onSubmit(): void {
    if (this.patientForm.valid) {
      const formData = this.patientForm.value;
      if (this.isEditing) {
        // Update existing patient
        this.patientService.updatePatient(formData).subscribe(() => {   
          this.closeModal.emit();     
        });
      } else {
        // Add new patient
        this.patientService.addPatient(formData).subscribe( {
          next:()=>{
            this.patientForm.reset();
          }
        });
      }
    }
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
