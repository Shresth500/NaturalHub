import { Component, Input } from '@angular/core';
import { IProducts } from '../../../../../models/modelsInterface';
import { TruncatePipe } from '../../../../common/Pipes/truncate.pipe';
import { ProfileService } from '../../../../User/Profile/profile.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-items',
  standalone: true,
  imports: [TruncatePipe, RouterLink],
  templateUrl: './items.component.html',
  styleUrl: './items.component.scss',
})
export class ItemsComponent {
  @Input() items!: any;
  constructor() {}
}
