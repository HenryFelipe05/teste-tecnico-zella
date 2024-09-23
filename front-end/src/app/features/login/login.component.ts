import { Component } from '@angular/core';
import { AuthService } from '../../shared/service/auth/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  senha: string = '';
  mensagemErro: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    this.authService.login(this.email, this.senha).subscribe({
      next: (response) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/home']); 
      },
      error: (err) => {
        this.mensagemErro = 'Falha no login. Verifique suas credenciais.';
      }
    });
  }

  goToRegister() {
    this.router.navigate(['/register']);
  }
}