import { Component, Input } from '@angular/core';
import { IHealthTips } from '../../../../models/modelsInterface';
import { AuthService } from '../../../common/auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-tips',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './tips.component.html',
  styleUrl: './tips.component.scss',
})
export class TipsComponent {
  @Input() healthtips!: IHealthTips;

  showFullList = true; // Toggle for full list
  visibleLimit = 1; // Number of items to show initially

  toggleList() {
    this.showFullList = !this.showFullList;
  }

  constructor(private authService: AuthService) {}
  isAdmin(): boolean {
    return this.authService.getRole() === 'Admin';
  }
}
