import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { TarefaQuery } from '../../../core/models/tarefa-query.model';

@Injectable({
  providedIn: 'root'
})
export class TarefaService {
  private tarefasSubject = new BehaviorSubject<any[]>([]);
  public tarefas$ = this.tarefasSubject.asObservable();
  private apiUrl = 'https://localhost:44368/api/Tarefa';
  private headers = new HttpHeaders({ 'Authorization': `Bearer ${localStorage.getItem('token')}` });

  constructor(private http: HttpClient) { }

  recuperarTarefas(): Observable<TarefaQuery[]> {
    return this.http.get<TarefaQuery[]>(`${this.apiUrl}/tarefas-usuario`, { headers: this.headers });
  }

  recuperarDetalhesTarefa(codigoTarefa: number): Observable<TarefaQuery> {
    return this.http.get<TarefaQuery>(`${this.apiUrl}/detalhes-tarefa/${codigoTarefa}`, { headers: this.headers });
  }

  adicionarTarefa(tarefa: TarefaQuery): Observable<TarefaQuery> {
    return this.http.post<TarefaQuery>(`${this.apiUrl}/nova-tarefa`, tarefa, { headers: this.headers });
  }

  alterarTarefa(tarefa: TarefaQuery): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/alterar-tarefa/${tarefa.codigoTarefa}`, tarefa, { headers: this.headers });
  }

  concluirTarefa(codigoTarefa: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/alterar-status/${codigoTarefa}`, null, { headers: this.headers });
  }

  excluirTarefa(codigoTarefa: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${codigoTarefa}`, { headers: this.headers });
  }

  setTarefas(tarefas: any[]): void {
    this.tarefasSubject.next(tarefas);
  }

  limparTarefas(): void {
    this.tarefasSubject.next([]);
  }
}
