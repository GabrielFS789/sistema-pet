import { Routes } from '@angular/router';
import { DashboardComponent } from './core/pages/dashboard/dashboard.component';

export const routes: Routes = [
  {
    path: 'login',
    title: 'Login',
    loadComponent: () =>
      import('./core/pages/login/login.component').then((c) => c.LoginComponent),
  },
  {
    path: 'dashboard',
    title: 'Dashboard',
    loadComponent: () => import('./core/pages/dashboard/dashboard.component').then(c => c.DashboardComponent)
  },
  {
    path: 'pets',
    title: 'Pets',
    loadComponent: () =>
      import('./pages/pets/pets/pets.component').then((c) => c.PetsComponent),
  },
  {
    path: 'pets/:id',
    title: 'Pet Detail',
    loadComponent: () => import('./pages/pets/pet-detail/pet-detail.component').then((c) => c.PetDetailComponent)
  },
  {
    path: 'raca',
    title: 'Raças',
    loadComponent: () =>
      import('./pages/raca/raca/raca.component').then((c) => c.RacaComponent),
  },
  {
    path: 'raca/:id',
    title: 'Detalhe',
    loadComponent: () =>
      import('./pages/raca/raca-detail/raca-detail.component').then(
        (c) => c.RacaDetailComponent
      ),
  },
  {
    path: '*',
    component: DashboardComponent
  },
];
