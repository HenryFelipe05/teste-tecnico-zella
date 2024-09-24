import { Component } from '@angular/core';
import { AuthService } from '../../shared/service/auth/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  email: string = '';
  senha: string = '';
  senhaConfirmada: string = '';
  codigoGenero: number = 0;
  mensagemErro: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  onRegister() {
    if (this.senha != this.senhaConfirmada) {
      this.mensagemErro = 'Falha no cadastro. As senhas não são iguais.';
      return;
    }

    this.authService.register(this.email, this.senha, this.codigoGenero).subscribe({
      next: (response) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/login']);
      },
      error: (err) => {
        this.mensagemErro = 'Falha no cadastro. Verifique suas credenciais.';

        if (err.error && err.error.message) {
          this.mensagemErro = err.error.message; 
        }
      }
    });

  }

  goToLogin() {
    this.router.navigate(['/login']);
  }
}
