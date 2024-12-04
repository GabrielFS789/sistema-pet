import { inject, Injectable } from '@angular/core';
import { jwtVerify } from 'jose';
import { Router } from 'express';
import { ESessionStorage } from '../../enums/ESessionStorage.enum';

@Injectable({
  providedIn: 'root'
})
export class ValidaTokenService {

  #router = inject(Router)

  async validaToken(): Promise<Boolean>{
    if(typeof window !== 'undefined' && typeof window !== 'undefined'){
      const secretKey = new TextEncoder().encode("\\_d1*.MQ61;2'xGWk~{;HHl24DG&'N+m)D?7~2nanFpO\\7E?`O")
      const token = sessionStorage.getItem(ESessionStorage.TOKEN)
      if(!token){
        console.error('Token não localizado')
        this.#router.navigate(['login'])
        return false
      }
      try{

        const { payload } = await jwtVerify(token, secretKey)
        if(payload.exp && Date.now() >= payload.exp * 1000){
          console.log('Token Expirado')
          return false;
        }
        console.log('Token Valido', payload)
        return true

      }catch(err) {
        console.error('Token inválido ou alterado', err);
      this.logout(); // Se o token foi alterado, apaga e redireciona
      return false;
      }
    }
    return false;
  }
  logout(){
   sessionStorage .removeItem(ESessionStorage.TOKEN)
   this.#router.navigate(['login'])
  }
}
