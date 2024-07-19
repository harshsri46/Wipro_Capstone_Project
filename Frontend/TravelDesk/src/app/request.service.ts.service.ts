import { Injectable,Inject,PLATFORM_ID } from '@angular/core';
import { HttpClient,HttpErrorResponse } from '@angular/common/http';
import { Observable,catchError,of } from 'rxjs';
import { RequestServiceInterfaceTsService,RequestApprovalDto,RequestCommentsDto } from './request.service.interface.ts.service';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class RequestServiceTsService {
  private apiUrl = 'http://localhost:5116/api/Manager'; // Your backend URL

  constructor(private http:HttpClient) { }
  getAssignedRequests(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}/assigned-requests`)
      .pipe(
        catchError(this.handleError<string[]>('getAssignedRequests', []))
      );
  }
 
  approveRequest(dto: RequestApprovalDto): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/approve`, dto)
      .pipe(
        catchError(this.handleError<void>('approveRequest'))
      );
  }

  disapproveRequest(dto: RequestApprovalDto): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/disapprove`, dto)
      .pipe(
        catchError(this.handleError<void>('disapproveRequest'))
      );
  }

  returnRequest(dto: RequestApprovalDto): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/return`, dto)
      .pipe(
        catchError(this.handleError<void>('returnRequest'))
      );
  }

  getRequestStatus(requestId: string): Observable<string> {
    return this.http.get<string>(`${this.apiUrl}/status/${requestId}`)
      .pipe(
        catchError(this.handleError<string>('getRequestStatus', 'Pending'))
      );
  }

  updateComments(dto: RequestCommentsDto): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/update-comments`, dto)
      .pipe(
        catchError(this.handleError<void>('updateComments'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: HttpErrorResponse): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

}
