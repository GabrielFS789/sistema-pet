import { Component, inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { IRaca } from '../../../Interfaces/IRaca.interface';
import { RacaService } from '../../raca/raca.service';

import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IPet } from '../../../Interfaces/IPet.Interface';
import { PetsService } from '../pets.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogCadastraRacaComponent } from '../../raca/components/dialog-cadastra-raca/dialog-cadastra-raca.component';
import { NgFor } from '@angular/common';
import { NavigateService } from '../../../functions/Navigate';

interface ISexo {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-pet-detail',
  imports: [MaterialModule, ReactiveFormsModule, NgFor],
  templateUrl: './pet-detail.component.html',
  styleUrl: './pet-detail.component.scss',
})
export class PetDetailComponent implements OnInit {
  #navigateService: NavigateService = inject(NavigateService);
  #petIdEditar: number | null = null
  #racaService: RacaService = inject(RacaService);
  #petService: PetsService = inject(PetsService);
  #route: ActivatedRoute = inject(ActivatedRoute);
  readonly dialog: MatDialog = inject(MatDialog);
  #fb: FormBuilder = inject(FormBuilder);
  isEdit: boolean = false;
  pet?: IPet;

  petForm!: FormGroup;
  possuiMedos: boolean = false;

  sexos: ISexo[] = [
    {
      value: 'M',
      viewValue: 'Masculino',
    },
    {
      value: 'F',
      viewValue: 'Feminino',
    },
    {
      value: 'N',
      viewValue: 'Não Informado',
    },
  ];

  racas: IRaca[] = [];

  ngOnInit(): void {
    const petParam = this.#route.snapshot.params['id'];
    this.#racaService.getAll().subscribe();
    this.#racaService.racas$.subscribe((racas) => {
      this.racas = racas;
    });
    if (petParam != 'new') {
      this.isEdit = true;
      const id = parseInt(petParam, 10);
      this.#petIdEditar = id;
      this.#petService.getPetById(id).subscribe((pet) => {
        const doencasPet = JSON.parse(pet?.doencas || '');
        const fraturasPet = JSON.parse(pet?.fraturas || '');
        const medosPet = JSON.parse(pet?.medos || '');
        console.log(pet);
        this.pet = pet;
        this.createForm(pet);
        if (doencasPet) {
          for (let [i, d] of doencasPet.entries()) {
            this.doencas.push(
              this.#fb.group({
                doenca: [d.doenca || ''],
              })
            );
          }
        }
        if (fraturasPet) {
          for (let [i, d] of fraturasPet.entries()) {
            this.fraturas.push(
              this.#fb.group({
                fratura: [d.fratura || ''],
              })
            );
          }
        }
        if (medosPet) {
          for (let [i, d] of medosPet.entries()) {
            this.medos.push(
              this.#fb.group({
                medo: [d.medo || ''],
              })
            );
          }
        }
      });
      return;
    }
    this.createForm();
  }

  createForm(pet?: IPet) {
    this.petForm = this.#fb.group({
      id: this.#fb.control(0),
      donoEndereco: this.#fb.control<string | null>(
        pet?.donoEndereco || null,
        Validators.required
      ),
      donoNumeroEndereco: this.#fb.control<string | null>(
        pet?.donoNumeroEndereco || null
      ),
      donoComplemento: this.#fb.control<string | null>(
        pet?.donoComplemento || null
      ),
      donoTelefone: this.#fb.control<string | null>(
        pet?.donoTelefone || null,
        Validators.required
      ),
      donoNome: this.#fb.control<string | null>(
        pet?.donoNome || null,
        Validators.required
      ),
      petNome: this.#fb.control<string | null>(
        pet?.petNome || null,
        Validators.required
      ),
      petSexo: this.#fb.control<string | null>(
        pet?.petSexo || null,
        Validators.required
      ),
      petNascimento: this.#fb.control<string | null>(
        pet?.petNascimento || null
      ),
      racaId: this.#fb.control<string | null>(
        pet?.racaId || null,
        Validators.required
      ),
      doencas: new FormArray([]),
      fraturas: new FormArray([]),
      medos: new FormArray([]),
      gestante: this.#fb.control<boolean>(false),
    });
  }

  get doencas() {
    return this.petForm?.get('doencas') as FormArray;
  }

  get medos() {
    return this.petForm?.get('medos') as FormArray;
  }

  get fraturas() {
    return this.petForm?.get('fraturas') as FormArray;
  }

  adicionarRaca() {
    this.dialog.open(DialogCadastraRacaComponent);
  }

  addDoenca() {
    this.doencas.push(
      this.#fb.group({
        doenca: new FormControl(''),
      })
    );
  }

  removeDoenca(i: number) {
    this.doencas.removeAt(i);
  }

  addFratura() {
    this.fraturas.push(
      this.#fb.group({
        fratura: new FormControl(''),
      })
    );
  }

  removeFratura(i: number) {
    this.fraturas.removeAt(i);
  }

  addMedo() {
    this.medos.push(
      this.#fb.group({
        medo: new FormControl(''),
      })
    );
  }

  removeMedo(i: number) {
    this.medos.removeAt(i);
  }

  add() {

    const doencas = this.doencas.value.map((doenca: any) => ({
      doenca: doenca.doenca || '',
    }));
  
    const fraturas = this.fraturas.value.map((fratura: any) => ({
      fratura: fratura.fratura || '',
    }));
  
    const medos = this.medos.value.map((medo: any) => ({
      medo: medo.medo || '',
    }));

    const petData = {
      ...this.petForm.value,
      doencas: JSON.stringify(doencas), // Convertendo o array para string JSON
    fraturas: JSON.stringify(fraturas), // Convertendo o array para string JSON
    medos: JSON.stringify(medos), // Convertendo o array para string JSON
    }
    console.log(petData)
    this.#petService.createPet(petData).subscribe(() => {
      this.#navigateService.goBack();
    });
  }

  update(){
    const doencas = this.doencas.value.map((doenca: any) => ({
      doenca: doenca.doenca || '',
    }));
  
    const fraturas = this.fraturas.value.map((fratura: any) => ({
      fratura: fratura.fratura || '',
    }));
  
    const medos = this.medos.value.map((medo: any) => ({
      medo: medo.medo || '',
    }));

    const petData = {
      ...this.petForm.value,
      doencas: JSON.stringify(doencas), // Convertendo o array para string JSON
    fraturas: JSON.stringify(fraturas), // Convertendo o array para string JSON
    medos: JSON.stringify(medos), // Convertendo o array para string JSON
    }
    console.log(petData)
    this.#petService.updatePet(this.#petIdEditar!, petData).subscribe(() => this.#navigateService.goBack())
  }
}
