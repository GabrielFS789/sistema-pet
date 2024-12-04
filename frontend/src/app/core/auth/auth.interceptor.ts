import { HttpInterceptorFn } from '@angular/common/http';
import { ELocalStorage } from '../../enums/ELocalStorage.Enum';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const token = sessionStorage.getItem(ELocalStorage.TOKEN)

  if(token){
    const cloneRequest = req.clone({
      setHeaders:{
        Authorization: `Bearer ${token}`
      }
    })
    return next(cloneRequest)
  }
  return next(req)
};
