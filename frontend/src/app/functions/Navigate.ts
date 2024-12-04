import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class NavigateService {
  #router: Router = inject(Router);

  goBack() {
    if (window.history.length > 1) {
      window.history.back();
    } else {
      this.#router.navigate(['../'], { relativeTo: undefined });
    }
  }
}
