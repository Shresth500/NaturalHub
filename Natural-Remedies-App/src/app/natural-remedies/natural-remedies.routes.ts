import { Routes } from '@angular/router';
import { NaturalRemediesComponent } from './natural-remedies/natural-remedies.component';
import { authGuard } from '../common/auth/auth.guard';
import { RemediesComponent } from './Remedies/remedies/remedies.component';
import { HealthTipsComponent } from './HealthTips/health-tips/health-tips.component';
import { ShoppingCartComponent } from './ShoppingCart/shopping-cart/shopping-cart.component';
import { ProfileComponent } from '../User/Profile/profile/profile.component';
import { OrderComponent } from '../User/Profile/Order/order/order.component';
import { CartsComponent } from '../User/Profile/Order/carts/carts.component';
import { ItemsDataComponent } from '../ShoppingCart/Items/items-data/items-data.component';

export const routes: Routes = [
  {
    path: 'home',
    redirectTo: '/',
    pathMatch: 'prefix',
  },
  {
    path: '',
    component: NaturalRemediesComponent,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        redirectTo: 'remedies',
        pathMatch: 'full',
      },
      {
        path: 'remedies',
        component: RemediesComponent,
        //pathMatch: 'full',
        canActivate: [authGuard],
      },
      {
        path: 'healthtips',
        component: HealthTipsComponent,
        canActivate: [authGuard],
      },
      {
        path: 'shoppingcart',
        component: ShoppingCartComponent,
        canActivate: [authGuard],
      },
      {
        path: 'shoppingcart/:productid',
        component: ItemsDataComponent,
        canActivate: [authGuard],
      },
      {
        path: 'profile/:username',
        component: ProfileComponent,
        canActivate: [authGuard],
      },
      {
        path: 'profile/:username/carts',
        component: CartsComponent,
        canActivate: [authGuard],
      },
    ],
  },
];
