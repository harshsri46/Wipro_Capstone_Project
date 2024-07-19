import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs';



interface LoginResponse {
  token: string;
  role: string;
}
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private loginUrl = 'http://localhost:5116/api/Auth/login'; // Replace with your backend API URL

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.loginUrl, { email, password }).pipe(
      tap(response => {
        // Store the token and role in localStorage
        localStorage.setItem('token', response.token);
        localStorage.setItem('role', response.role);
      })
    );
  }
  logout() {
    // Remove user token from local storage or session storage
    localStorage.removeItem('token');
    localStorage.removeItem('role')
  }

  isAuthenticated(): boolean {
    // Check if user is authenticated based on token presence
    return !!localStorage.getItem('token');
  }

  getRole(): string | null {
    return localStorage.getItem('role');
  }


}
