import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { IPatient } from '../patient/Models/IPatient';
import { IPatientForUpdateDto } from '../patient/Models/IPatientForUpdateDto';
import { IPatientForAddDto } from '../patient/Models/IPatientForAddDto';

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

  getPatients(pageNumber: number, pageSize: number, name?: string, fileNo?: number, phoneNumber?: string)
    : Observable<HttpResponse<IPatient[]>> {
    let url = `${this.apiUrl}Patients?pageNumber=${pageNumber}&pageSize=${pageSize}`;

    if (name) {
      url += `&name=${name}`;
    }
    if (fileNo) {
      url += `&fileNo=${fileNo}`;
    }
    if (phoneNumber) {
      url += `&phoneNumber=${phoneNumber}`;
    }

    const httpOptions = {
      withCredentials: true
    };

    return this.http.get<IPatient[]>(url, { observe: 'response', ...httpOptions }).pipe(
      tap(response => {
        console.log('paginationData : ' + response.headers.get('x-pagination'));
      }),
      catchError(this.handleError)
    );
  }



  handleError(error: HttpErrorResponse) {
    let errorMessage: string = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = ` client-side error` + error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status} Message : ${error?.message}`;
    }
    console.log(errorMessage);
    return throwError(() => errorMessage);
  }
}
