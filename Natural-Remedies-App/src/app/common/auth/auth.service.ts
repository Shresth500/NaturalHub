import { Injectable } from '@angular/core';
import { ILogin, ISignUp } from '../../../models/modelsInterface';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly AUTH_KEY = 'auth';
  private apiUrl = `https://localhost:7218`;
  constructor(private http: HttpClient) {}
  signin(credentials: ISignUp) {
    return this.http.post<string>(
      `${this.apiUrl}/api/auth/register/`,
      credentials,
      {
        responseType: 'text' as 'json', // 'json' is required here for type compatibility
      }
    );
  }
  login(credentials: ILogin) {
    return this.http
      .post<ILogin>(`${this.apiUrl}/api/auth/login`, credentials, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .pipe(
        tap((loginResponse) => {
          localStorage.setItem(this.AUTH_KEY, JSON.stringify(loginResponse));
        })
      );
  }
  logout() {
    localStorage.removeItem(this.AUTH_KEY);
    if (localStorage.getItem('auth') !== null) {
      return false;
    }
    return true;
  }
  getUser() {
    const authStr = localStorage.getItem(this.AUTH_KEY);
    if (!authStr) return '';
    return JSON.parse(authStr);
  }
  getRole() {
    const authStr = localStorage.getItem(this.AUTH_KEY);
    if (!authStr) return '';
    let value = JSON.parse(authStr);
    return value['role'];
  }

  getToken() {
    const authStr = localStorage.getItem(this.AUTH_KEY);
    if (!authStr) return '';
    let value = JSON.parse(authStr);
    return value['token'];
  }
  isloggedin() {
    const authStr = localStorage.getItem(this.AUTH_KEY);

    if (!authStr) return false;
    return true;
  }
}
