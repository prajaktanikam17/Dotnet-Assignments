import { Routes } from '@angular/router';
import { Home } from './home/home';
import { About } from './about/about';
import { authGuard } from './auth-guard';

export const routes: Routes = [

  {
    path: '',
    redirectTo: ' ',
    pathMatch: 'full'
  },

  {
    path: 'home',
    component: Home
  },

  {
    path: 'about',
    component: About
  },

  {
    
    path: 'admin',
    loadComponent: () =>
    import('./admin/admin')
      .then(m => m.Admin),
    canActivate: [authGuard]
  }

];