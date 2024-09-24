import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioQuery } from '../../../core/models/usuario-query.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private apiUrl = 'https://localhost:44368/api/Usuario';
  private headers = new HttpHeaders({ 'Authorization': `Bearer ${localStorage.getItem('token')}` });

  constructor(private http: HttpClient) { }

  recuperarDadosUsuario(): Observable<UsuarioQuery> {
    return this.http.get<UsuarioQuery>(`${this.apiUrl}/usuario`, { headers: this.headers });
  }

  atualizarUsuario(usuario: UsuarioQuery): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/atualizar-usuario`, usuario, { headers: this.headers });
  }
}
