import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ValidaTokenService } from '../auth/valida-token.service';

export const authGuard: CanActivateFn = async (route, state) => {
  const router = inject(Router)
  const authService = inject(ValidaTokenService)

  const isTokenValid = await authService.validaToken();
  
  if(!isTokenValid){
    router.navigate(['login'])
    return false
  }
  return true
};
