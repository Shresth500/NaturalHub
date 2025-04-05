import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { NgModel } from '@angular/forms';
import { ISignUp } from '../../../../models/modelsInterface';
import { AuthService } from '../../../common/auth/auth.service';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss',
})
export class SignupComponent {
  loading = false;
  returnUrl!: string;
  credentials!: ISignUp;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {}

  sigin(form: NgForm) {
    this.credentials = { ...form.value };
    this.credentials.roles = ['User'];
    this.authService.signin(this.credentials).subscribe({
      next: (registered) => {
        console.log(registered);
        this.router.navigate(['/auth', 'login']);
      },
    });
  }
}
