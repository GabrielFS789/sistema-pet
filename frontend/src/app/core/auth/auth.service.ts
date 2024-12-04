import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { IUser } from '../../Interfaces/IUser.Interface';
import { environment } from '../../../environments/environment';
import { ILogin } from '../../Interfaces/ILogin.interface';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ESessionStorage } from '../../enums/ESessionStorage.enum';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginErrorComponent } from '../components/dialogs/login-error/login-error.component';
import { ValidaTokenService } from './valida-token.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(
    false
  );
  public isLogged$: Observable<boolean> = this.loggedIn.asObservable();
  #snackBar = inject(MatSnackBar);
  durationSnackBar = 1;

  #router = inject(Router);
  #apiUrl: string = `${environment.apiBackend}/api/login`;
  #http = inject(HttpClient);

  constructor() {
    if (typeof window !== 'undefined' && typeof window !== 'undefined') {
      const token = sessionStorage.getItem(ESessionStorage.TOKEN);
      if (token) this.loggedIn.next(true);
    }
  }

  onLogin(login: ILogin): Observable<any> {
    return this.#http.post<any>(this.#apiUrl, login).pipe(
      tap(
        (res) => {
          const { token } = res;
          if (token) {
            sessionStorage.setItem(ESessionStorage.TOKEN, token);
            this.loggedIn.next(true);
            this.#router.navigate(['/']);
          }
        },
        (err) => {
          if (err.status === 401) {
            this.#snackBar.openFromComponent(LoginErrorComponent, {
              duration: this.durationSnackBar * 1000,
            });
          }
        }
      )
    );
  }
  logout() {
    this.loggedIn.next(false);
    sessionStorage.removeItem(ESessionStorage.TOKEN);
    this.#router.navigate(['login']);
  }
}
