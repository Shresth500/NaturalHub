import { Routes } from '@angular/router';
import { AuthComponent } from './auth/auth/auth.component';
import { LoginComponent } from './login/login/login.component';
import { SignupComponent } from './singup/signup/signup.component';

export const routes: Routes = [
  {
    path: 'auth',
    component: AuthComponent,
    title: 'Workshop Details',
    children: [
      {
        path: 'login',
        component: LoginComponent,
      },
      {
        path: 'register',
        component: SignupComponent,
      },
    ],
  },
];
