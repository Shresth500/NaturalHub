import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '../profile.service';
import {
  IProducts,
  IUserProductCatalog,
} from '../../../../models/modelsInterface';
import { Component, inject, signal, WritableSignal } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent {
  count = 0;
  username: string | null = '';
  userProfile!: IUserProductCatalog;

  constructor(
    private route: ActivatedRoute,
    private profileService: ProfileService
  ) {}

  ngOnInit() {
    this.count = 0;
    this.username = this.route.snapshot.paramMap.get('username');
    if (this.username === null) {
      return;
    }
    this.profileService.getUser(this.username).subscribe({
      next: (result) => {
        this.userProfile = result;
        console.log(result);
      },
    });
  }
  getOrderCount(): number {
    return ++this.count; // Increment and return count
  }
}
