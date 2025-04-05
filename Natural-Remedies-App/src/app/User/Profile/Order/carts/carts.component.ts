import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '../../profile.service';
import { IUserProductCatalog } from '../../../../../models/modelsInterface';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-carts',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './carts.component.html',
  styleUrl: './carts.component.scss',
})
export class CartsComponent {
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

  BuyCart() {
    this.profileService.postFromCarts().subscribe({
      next: (result) => {
        this.userProfile = result;
      },
    });
  }
}
