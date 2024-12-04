import { Component, EventEmitter, Output } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { RouterLink } from '@angular/router';
export interface Section {
  name: string;
  description: string;
  iconName: string;
  routerLink: string;
}


@Component({
    selector: 'app-list-sidebar',
    imports: [MaterialModule, RouterLink],
    templateUrl: './list-sidebar.component.html',
    styleUrl: './list-sidebar.component.scss'
})
export class ListSidebarComponent {
  @Output() menuSelectEmitter = new EventEmitter<void>()

  menuSelect(){
    this.menuSelectEmitter.next();
  }

  menus: Section[] = [
    {
      iconName: 'pets',
      name: 'Pets',
      description: 'Cadastro de pets',
      routerLink: 'pets'
    },
    {
      routerLink: 'raca',
      iconName: 'pets',
      name: 'Raças',
      description: 'Cadastro de Raça',
    },
  ];
  configs: Section[] = [
    {
      iconName: 'settings',
      name: 'Configurações',
      description: 'Configurações do sistema',
      routerLink: 'settings'
    },
  ]
}
