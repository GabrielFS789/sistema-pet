import { Component, inject, model } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { IRaca } from '../../../../Interfaces/IRaca.interface';

@Component({
    selector: 'app-dialog-delete',
    imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent],
    templateUrl: './dialog-delete.component.html',
    styleUrl: './dialog-delete.component.scss'
})
export class DialogDeleteComponent {
  readonly dialogRef = inject(MatDialogRef<DialogDeleteComponent>);
  readonly data = inject<IRaca>(MAT_DIALOG_DATA)


  noDelete(): void{
    this.dialogRef.close()
  }
}
