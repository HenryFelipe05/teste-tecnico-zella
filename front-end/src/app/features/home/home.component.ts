import { Component, ElementRef, HostListener } from '@angular/core';
import { TarefaComponent } from './components/tarefa/tarefa.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faAnglesUp } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    TarefaComponent,
    NavbarComponent,
    FontAwesomeModule
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  faAnglesUp = faAnglesUp;
  showScrollToTopBtn: boolean = false;

  constructor(private el: ElementRef) {}

  ngAfterViewInit() {
    const container = this.el.nativeElement.querySelector('.container');
    container.addEventListener('scroll', this.onContainerScroll.bind(this));
  }

  onContainerScroll(event: any) {
    const scrollPosition = event.target.scrollTop || 0;
    this.showScrollToTopBtn = scrollPosition > 200;
  }

  scrollToTop(): void {
    const container = this.el.nativeElement.querySelector('.container');
    container.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
