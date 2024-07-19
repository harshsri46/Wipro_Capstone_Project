import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable,throwError } from 'rxjs';
import { UserDTO,UpdateUserDTO,CreateUserDTO } from './user.dto';
import { HttpErrorResponse} from '@angular/common/http';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = `${environment.apiBaseUrl}/admin`; // Ensure this URL is correct

  constructor(private http: HttpClient) { }
  getUser(id: string): Observable<UserDTO> {
    return this.http.get<UserDTO>(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  createUser(user: CreateUserDTO): Observable<UserDTO> {
    return this.http.post<UserDTO>(this.apiUrl, user).pipe(
      catchError(this.handleError)
    );
  }

  updateUser(id: string, user: UpdateUserDTO): Observable<UserDTO> {
    return this.http.put<UserDTO>(`${this.apiUrl}/${id}`, user).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    // You can perform error handling here and log it if needed
    console.error('An error occurred:', error.message);
    return throwError('Something went wrong; please try again later.');
  }
  
}
 
