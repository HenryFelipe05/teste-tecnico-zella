import { Routes } from '@angular/router';
import { LoginComponent } from './features/login/login.component';
import { RegisterComponent } from './features/register/register.component';
import { HomeComponent } from './features/home/home.component';
import { TarefaFormComponent } from './features/cadastros/form-tarefa/form-tarefa.component'
import { FormUsuarioComponent } from './features/cadastros/form-usuario/form-usuario.component'

export const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'home', component: HomeComponent },
    { path: 'form-tarefa', component: TarefaFormComponent },
    { path: 'form-tarefa/:codigoTarefa', component: TarefaFormComponent },
    { path: 'form-usuario', component: FormUsuarioComponent },
    { path: '', redirectTo: '/login', pathMatch: 'full' }
  ];
  
