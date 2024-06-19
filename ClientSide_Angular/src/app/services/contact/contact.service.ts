import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiUrl = 'https://localhost:7251/api/Contacts'; // Replace with your API URL

  constructor(private http: HttpClient) {}

  // Example method to get data from the API
  getContacts(): Observable<any> {
    return this.http
      .get<any>(`${this.apiUrl}`)
      .pipe(catchError(this.handleError));
  }

  // Example method to post data to the API
  addContact(data: any): Observable<any> {
    return this.http
      .post<any>(`${this.apiUrl}`, data)
      .pipe(catchError(this.handleError));
  }

  // Handle errors
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // Return an observable with a user-facing error message.
    return throwError('Something bad happened; please try again later.');
  }
}
