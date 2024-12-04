import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { IRaca } from '../../Interfaces/IRaca.interface';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RacaService {
  private racasSubject: BehaviorSubject<IRaca[]> = new BehaviorSubject<IRaca[]>([]);
  public racas$: Observable<IRaca[]> = this.racasSubject.asObservable();
  #http:HttpClient = inject(HttpClient)
  #apiUrl = `${environment.apiBackend}/api/raca`



  getUrlById(id: number){
    return `${this.#apiUrl}/${id}`
  }

  getAll(): Observable<IRaca[]> {
    return this.#http.get<IRaca[]>(this.#apiUrl).pipe(
      tap(racas => this.racasSubject.next(racas))
    )
  }
  getById(id: number) : Observable<IRaca | undefined>{
    return this.#http.get<IRaca | undefined>(this.getUrlById(id))
  }

  deleteById(id: number): Observable<IRaca | undefined> {
    return this.#http.delete<IRaca>(this.getUrlById(id)).pipe(tap(
      () => {
        const racas = this.racasSubject.getValue().filter(raca => raca.id !== id);
        this.racasSubject.next(racas)
      }
    ))
  }

  create(raca: IRaca): Observable<IRaca[]>{
    return this.#http.post<IRaca[]>(this.#apiUrl, raca).pipe(
      tap(racas => this.racasSubject.next(racas))
    )
  }

  update(id: number, raca: IRaca):Observable<IRaca>{
    return this.#http.patch<IRaca>(`${this.#apiUrl}/${id}`, raca)
  }
  
}
