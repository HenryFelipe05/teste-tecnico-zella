import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TarefaService } from '../../../shared/service/tarefa/tarefa.service';
import { TarefaQuery } from '../../../core/models/tarefa-query.model';
import { ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tarefa-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './form-tarefa.component.html',
  styleUrls: ['./form-tarefa.component.css']
})
export class TarefaFormComponent implements OnInit {
  @Input() tarefa?: TarefaQuery;
  tarefaForm!: FormGroup;
  isEdit: boolean = false;
  codigoTarefa!: number;

  constructor(
    private fb: FormBuilder,
    private tarefaService: TarefaService,
    private router: Router,
    private route: ActivatedRoute 
  ) { }

  ngOnInit(): void {
    this.checkEditMode(); 
    this.initializeForm();
  }

  checkEditMode(): void {
    const codigo = this.route.snapshot.paramMap.get('codigoTarefa');
    if (codigo) {
      this.codigoTarefa = +codigo;
      this.isEdit = true;
      this.loadTarefa(this.codigoTarefa);
    }
  }

  loadTarefa(codigoTarefa: number): void {
    this.tarefaService.recuperarDetalhesTarefa(codigoTarefa).subscribe(tarefa => {
      this.tarefa = tarefa;
      this.initializeForm();
    });
  }

  initializeForm(): void {
    this.tarefaForm = this.fb.group({
      nomeTarefa: [this.tarefa?.nomeTarefa || '', Validators.required],
      descricaoTarefa: [this.tarefa?.descricaoTarefa || '', Validators.required],
      codigoStatusTarefa: [this.tarefa?.codigoStatusTarefa === 2]
    });
  }

  backToHome(): void {
    this.router.navigate(['/home']);
  }

  onSubmit(): void {
    if (this.tarefaForm.valid) {
      const tarefaData: TarefaQuery = {
        ...this.tarefa,
        nomeTarefa: this.tarefaForm.value.nomeTarefa,
        descricaoTarefa: this.tarefaForm.value.descricaoTarefa,
        codigoStatusTarefa: this.tarefaForm.value.codigoStatusTarefa ? 2 : 1
      };

      if (this.isEdit) {
        this.tarefaService.alterarTarefa(tarefaData).subscribe(() => {
          this.router.navigate(['/home']);
        });
      } else {
        this.tarefaService.adicionarTarefa(tarefaData).subscribe(() => {
          this.router.navigate(['/home']);
        });
      }
    }
  }
}