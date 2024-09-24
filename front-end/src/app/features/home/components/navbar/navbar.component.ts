import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faUserGear, faRightFromBracket } from '@fortawesome/free-solid-svg-icons';
import { TarefaService } from '../../../../shared/service/tarefa/tarefa.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [FontAwesomeModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  faUserGear = faUserGear;
  faRightFromBracket = faRightFromBracket;

  constructor(private router: Router, private tarefaService: TarefaService) {}

  logofUsuario(): void {
    this.tarefaService.limparTarefas();
    this.router.navigate(['/login']);
  }

  carregarFormUsuario(): void {
    this.router.navigate(['/form-usuario']);
  }
}
