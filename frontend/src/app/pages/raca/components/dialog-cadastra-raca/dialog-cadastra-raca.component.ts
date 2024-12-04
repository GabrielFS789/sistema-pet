import { Component, inject } from '@angular/core';
import { MaterialModule } from '../../../../material/material.module';
import {
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
} from '@angular/material/dialog';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { IRaca } from '../../../../Interfaces/IRaca.interface';
import { RacaService } from '../../raca.service';

@Component({
  selector: 'app-dialog-cadastra-raca',
  imports: [
    MaterialModule,
    MatDialogContent,
    MatDialogActions,
    ReactiveFormsModule,
  ],
  templateUrl: './dialog-cadastra-raca.component.html',
  styleUrl: './dialog-cadastra-raca.component.scss',
})
export class DialogCadastraRacaComponent {
  isSubmitting = false;
  readonly dialogRef = inject(MatDialogRef<DialogCadastraRacaComponent>);
  #racaService: RacaService = inject(RacaService);
  racaDetail = new FormGroup({
    id: new FormControl<number | null>({ value: 0, disabled: true }),
    nome: new FormControl<string | null>(''),
    inativo: new FormControl<boolean>(false),
    dataHoraCadastro: new FormControl<string | null>({
      value: null,
      disabled: true,
    }),
  });

  close(): void {
    this.dialogRef.close();
  }
  adicionar() {
    console.log(this.racaDetail.value);
    this.#racaService.create(this.racaDetail.value as IRaca).subscribe(() => {
      this.#racaService.getAll().subscribe(
        () => this.dialogRef.close()
      )
    })
 
  }
}
