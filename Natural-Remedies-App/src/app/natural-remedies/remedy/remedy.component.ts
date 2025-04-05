import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IRemedies } from '../../../models/modelsInterface';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../common/auth/auth.service';

@Component({
  selector: 'app-remedy',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './remedy.component.html',
  styleUrl: './remedy.component.scss',
})
export class RemedyComponent {
  @Input() remedy!: IRemedies;
  @Output() Updating = new EventEmitter<{ Id: number }>();

  showFullList = true; // Toggle for full list
  visibleLimit = 3; // Number of items to show initially

  toggleList() {
    this.showFullList = !this.showFullList;
  }

  constructor(private authService: AuthService) {}
  isAdmin(): boolean {
    return this.authService.getRole() === 'Admin';
  }
}
