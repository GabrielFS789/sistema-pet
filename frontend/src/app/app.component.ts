import { Component, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MaterialModule } from './material/material.module';
import { MatDrawer } from '@angular/material/sidenav';
import { ListSidebarComponent } from './core/components/list-sidebar/list-sidebar.component';
import { CommonModule } from '@angular/common';
import { ToolbarComponent } from './core/components/toolbar/toolbar.component';
import { AuthService } from './core/auth/auth.service';
import { LoginComponent } from "./core/pages/login/login.component";

@Component({
    selector: 'app-root',
    imports: [RouterOutlet, ToolbarComponent, MaterialModule, ListSidebarComponent, CommonModule, LoginComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'frontend';
  isLogged:boolean = false

  constructor(private authService: AuthService){
    this.authService.isLogged$.subscribe((res) =>{
      this.isLogged = res
    })
  }
  user: boolean = !false;
  @ViewChild('drawer') drawer!: MatDrawer

  toggleSideBar(){
    this.drawer.toggle();
  }
}
