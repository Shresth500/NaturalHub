import { Component } from '@angular/core';
import {
  RouterOutlet,
  RouterLinkActive,
  Router,
  RouterLink,
  RouterModule,
} from '@angular/router';
import {
  NgbAlertModule,
  NgbCollapseModule,
  NgbDropdownModule,
  NgbNavModule,
} from '@ng-bootstrap/ng-bootstrap';
import { Remedy } from '../../../models/modelsInterface';
import { RemedyComponent } from '../remedy/remedy.component';
import { AuthService } from '../../common/auth/auth.service';

@Component({
  selector: 'app-natural-remedies',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLinkActive,
    RouterLink,
    RouterModule,
    NgbAlertModule,
    NgbCollapseModule,
    NgbDropdownModule,
    NgbNavModule,
    RemedyComponent,
  ],
  templateUrl: './natural-remedies.component.html',
  styleUrl: './natural-remedies.component.scss',
})
export class NaturalRemediesComponent {
  collapsed = true;
  isLoggedIn = false;
  isNavbarCollapsed = true;
  email!: string;

  constructor(private authServices: AuthService, private router: Router) {}

  getData() {
    let user = this.authServices.getUser();
    return user['userName'];
  }

  logout() {
    let isloggedout = this.authServices.logout();
    console.log(isloggedout);
  }
}
