import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MaterialModule } from '../../../material/material.module';
import { AuthService } from '../../auth/auth.service';
import { ILogin } from '../../../Interfaces/ILogin.interface';
import { ESessionStorage } from '../../../enums/ESessionStorage.enum';

@Component({
    selector: 'app-login',
    imports: [MaterialModule, ReactiveFormsModule],
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss'
})
export class LoginComponent {
  #authService = inject(AuthService)
  showPassword: boolean = false

  loginForm = new FormGroup({
    email: new FormControl<string | null>(null, Validators.required),
    password: new FormControl<string | null>(null, Validators.required)
  })
  login(){
    this.#authService.onLogin(this.loginForm.value as ILogin).subscribe()
  }
}
