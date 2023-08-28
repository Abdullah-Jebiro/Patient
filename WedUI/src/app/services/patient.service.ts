import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { IPatient } from '../patient/Models/IPatient';
import { IPatientForUpdateDto } from '../patient/Models/IPatientForUpdateDto';
import { IPatientForAddDto } from '../patient/Models/IPatientForAddDto';
import { IPatientSearchFilters } from '../patient/Models/IPatientSearchFilters';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  deletePatient(patientId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}Patients/${patientId}`)
      .pipe(catchError(this.handleError))
  }

  updatePatient(formData: IPatientForUpdateDto): Observable<IPatient> {
    const url = `${this.apiUrl}Patients`;
    return this.http.put<IPatient>(url, formData).pipe(
      catchError(this.handleError)
    );
  }

  addPatient(formData: IPatientForAddDto): Observable<number> {
    const url = `${this.apiUrl}Patients`;
    return this.http.post<number>(url, formData).pipe(
      catchError(this.handleError)
    );
  }


  getPatientById(patientId: string): Observable<IPatient> {
    return this.http.get<IPatient>(`${this.apiUrl}Patients/${patientId}`)
      .pipe(catchError(this.handleError))
  }



  /**
 * Retrieves a list of patients with optional filters and pagination.
 * @param pageNumber The page number.
 * @param pageSize The page size.
 * @param name The patient's name (optional).
 * @param fileNo The patient's file number (optional).
 * @param phoneNumber The patient's phone number (optional).
 * @returns An Observable with the list of patients and pagination data.
 */
  getPatients(
    pageNumber: number,
    pageSize: number,
    searchFilters: IPatientSearchFilters
  ): Observable<HttpResponse<IPatient[]>> {
    let url = `${this.apiUrl}Patients?`;

    if (searchFilters.name) {
      url += `&name=${searchFilters.name}`;
    }
    if (searchFilters.fileNo) {
      url += `&fileNo=${searchFilters.fileNo}`;
    }
    if (searchFilters.phoneNumber) {
      url += `&phoneNumber=${searchFilters.phoneNumber}`;
    }
    url += `&pageNumber=${pageNumber}&pageSize=${pageSize}`

    const httpOptions = {
      withCredentials: true
    };

    return this.http.get<IPatient[]>(url, { observe: 'response', ...httpOptions }).pipe(
      catchError(this.handleError)
    );
  }



  handleError(error: HttpErrorResponse) {
    let errorMessage: string = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = ` client-side error` + error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status} Message : ${error?.message}`;
      console.table(error.error.errors);

    }
    console.log(errorMessage);
    return throwError(() => errorMessage);
  }
}
