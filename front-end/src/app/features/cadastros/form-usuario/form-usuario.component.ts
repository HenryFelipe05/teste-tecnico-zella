import { Component, Input, OnInit } from '@angular/core';
import { UsuarioQuery } from '../../../core/models/usuario-query.model';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { UsuarioService } from '../../../shared/service/usuario/usuario.service';
import { AbstractControl, ValidatorFn } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { tap } from 'rxjs';

@Component({
  selector: 'app-form-usuario',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './form-usuario.component.html',
  styleUrls: ['./form-usuario.component.css']
})
export class FormUsuarioComponent implements OnInit {
  @Input() usuario?: UsuarioQuery;
  usuarioForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.initializeForm();
    if (!this.usuario) {
      this.carregarUsuario();
    }
  }

  carregarUsuario(): void {
    this.usuarioService.recuperarDadosUsuario().subscribe(usuario => {
      this.usuario = usuario;
      this.initializeForm();
    });
  }

  initializeForm(): void {
    this.usuarioForm = this.fb.group({
      email: [this.usuario?.email || '', Validators.required],
      senha: ['', Validators.required],
      senhaConf: ['', Validators.required],
      codigoGenero: [this.usuario?.codigoGenero || 3]
    }, { validators: this.senhasIguais });
  }

  senhasIguais: ValidatorFn = (control: AbstractControl): { [key: string]: boolean } | null => {
    const senha = control.get('senha')?.value;
    const senhaConf = control.get('senhaConf')?.value;

    return senha === senhaConf ? null : { senhasNaoIguais: true };
  };

  backToHome(): void {
    this.router.navigate(['/home']);
  }

  onSubmit(): void {
    if (this.usuarioForm.valid) {
      const usuarioData: UsuarioQuery = {
        ...this.usuario,
        email: this.usuarioForm.value.email,
        senha: this.usuarioForm.value.senha,
        codigoGenero: this.usuarioForm.value.codigoGenero
      };

      this.usuarioService.atualizarUsuario(usuarioData).pipe(
        tap(() => {
          this.router.navigate(['/login']);
        })
      ).subscribe({
        error: (error) => {
          console.error('Erro ao atualizar usuário:', error);
        }
      });

      this.router.navigate(['/login']);
    }
  }
}