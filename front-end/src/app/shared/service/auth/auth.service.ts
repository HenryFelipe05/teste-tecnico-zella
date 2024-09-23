import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private urlApi = 'https://localhost:44368/api/Autenticacao'; 

  constructor(private http: HttpClient) {}

  login(email: string, senha: string): Observable<any> {
    const dadosLogin = { email, senha };
    return this.http.post(`${this.urlApi}/login`, dadosLogin);
  }
}
