import { Component, EventEmitter, inject, Output } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { AuthService } from '../../auth/auth.service';

@Component({
    selector: 'app-toolbar',
    imports: [MaterialModule],
    templateUrl: './toolbar.component.html',
    styleUrl: './toolbar.component.scss'
})
export class ToolbarComponent {
  #authService = inject(AuthService)
  @Output() toggleSideBarEmitter = new EventEmitter<void>();
  
  logout(){
    this.#authService.logout();
  }
  toggleSideBar(){
    this.toggleSideBarEmitter.next()
  }
}
