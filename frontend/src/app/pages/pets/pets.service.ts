import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IPet } from '../../Interfaces/IPet.Interface';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PetsService {
  private PetSubject:BehaviorSubject<IPet[]> = new BehaviorSubject<IPet[]>([])
  public Pet$:Observable<IPet[]> = this.PetSubject.asObservable();
  #http: HttpClient = inject(HttpClient)

  #apiUrl = `${environment.apiBackend}/api/pet`

  getPets(): Observable<IPet[]>{
    return this.#http.get<IPet[]>(this.#apiUrl).pipe(tap
      (pets => this.PetSubject.next(pets))
    )
  }

  getPetById(id: number): Observable<IPet | undefined>{
    return this.#http.get<IPet | undefined>(this.getBydId(id))
  }

  createPet(pet: IPet): Observable<IPet[]>{
    console.log(pet)
    return this.#http.post<IPet[]>(this.#apiUrl, pet).pipe(
      tap(pets => this.PetSubject.next(pets))
    )
  }

  updatePet(id: number, pet: IPet): Observable<IPet>{
    return this.#http.patch<IPet>(this.getBydId(id), pet)
  }

  private getBydId(id:number){
    return `${this.#apiUrl}/${id}`
  }
}
