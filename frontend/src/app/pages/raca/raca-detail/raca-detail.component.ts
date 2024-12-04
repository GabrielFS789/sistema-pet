import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IRaca } from '../../../Interfaces/IRaca.interface';
import { RacaService } from '../raca.service';
import { MaterialModule } from '../../../material/material.module';
import { MatFormFieldAppearance } from '@angular/material/form-field';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
} from '@angular/forms';
import { NgIf } from '@angular/common';
import { getDataHora } from '../../../functions/toDateFuncion';
import { NavigateService } from '../../../functions/Navigate';


@Component({
    selector: 'app-raca-detail',
    imports: [MaterialModule, ReactiveFormsModule, NgIf],
    templateUrl: './raca-detail.component.html',
    styleUrl: './raca-detail.component.scss'
})
export class RacaDetailComponent {
  #route: ActivatedRoute = inject(ActivatedRoute);
  private readonly router = inject(Router);
  #navigateService:NavigateService = inject(NavigateService)


  #idRacaParaEditar:number = 0
  #racaService: RacaService = inject(RacaService);
  isEdit: boolean = true;
  appearance: MatFormFieldAppearance = 'outline';
  racaDetail = new FormGroup({
    id: new FormControl<number | null>({ value: 0, disabled: true }),
    nome: new FormControl<string | null>(''),
    inativo: new FormControl<boolean>(false),
    dataHoraCadastro: new FormControl<string | null>({
      value: null,
      disabled: true,
    }),
  });

  constructor() {
    const racaParam = this.#route.snapshot.params['id'];
    if (racaParam != 'new') {
      this.isEdit = false;
      this.#idRacaParaEditar = parseInt(racaParam, 10);
      this.#racaService.getById(this.#idRacaParaEditar).subscribe((raca) => {
        this.racaDetail.patchValue({
          id: raca?.id,
          nome: raca?.nome,
          inativo: raca?.inativo,
          dataHoraCadastro: getDataHora(raca!.dataHoraCadastro)
        });
        console.log(this.racaDetail.value)
      });
      return;
    }
  }
  cadastrar() {
    this.#racaService.create(this.racaDetail.value as IRaca).subscribe(() => {
      this.#navigateService.goBack()
      this.#racaService.getAll().subscribe();
    });
  }
  
  voltar(){
    this.#navigateService.goBack()
  }

  update() {
    this.#racaService.update(this.#idRacaParaEditar, this.racaDetail.value as IRaca).subscribe(() => {
      this.#navigateService.goBack()
      this.#racaService.getAll().subscribe();
    });
  }
}
