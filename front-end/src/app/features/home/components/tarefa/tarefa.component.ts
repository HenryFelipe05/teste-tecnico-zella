import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; 
import { CommonModule } from '@angular/common';
import { TarefaService } from '../../../../shared/service/tarefa/tarefa.service';
import { TarefaQuery } from '../../../../core/models/tarefa-query.model';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faCheck, faEdit, faTrash, faPlusCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-tarefa',
  standalone: true,
  imports: [CommonModule, FontAwesomeModule],
  templateUrl: './tarefa.component.html',
  styleUrls: ['./tarefa.component.css']
})
export class TarefaComponent implements OnInit {
  tarefas: TarefaQuery[] = [];
  faCheck = faCheck;
  faEdit = faEdit;
  faTrash = faTrash;
  faPlusCircle = faPlusCircle;

  constructor(private tarefaService: TarefaService, private router: Router) { }

  ngOnInit(): void {
    this.loadTarefas();
  }

  loadTarefas(): void {
    this.tarefaService.recuperarTarefas().subscribe({
      next: (tarefas) => {
        this.tarefas = tarefas;
      },
      error: (err) => {
        console.error('Erro ao carregar tarefas:', err);
      }
    });
  }

  adicionarTarefa(): void {
    this.router.navigate(['/form-tarefa']); 
  }

  concluirTarefa(codigoTarefa: number): void {
    this.tarefaService.concluirTarefa(codigoTarefa).subscribe(() => {
      this.loadTarefas();
    });
  }

  editarTarefa(codigoTarefa: number): void {
    this.router.navigate(['/form-tarefa', codigoTarefa]);
  }

  excluirTarefa(codigoTarefa: number): void {
    this.tarefaService.excluirTarefa(codigoTarefa).subscribe(() => {
      this.loadTarefas();
    });
  }
}