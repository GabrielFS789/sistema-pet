import { Component, inject } from '@angular/core';
import { MatSnackBarRef } from '@angular/material/snack-bar';
import { MaterialModule } from '../../../../material/material.module';


@Component({
    selector: 'app-login-error',
    imports: [MaterialModule],
    templateUrl: './login-error.component.html',
    styleUrl: './login-error.component.scss'
})
export class LoginErrorComponent {
  snackBarRef = inject(MatSnackBarRef)
}
