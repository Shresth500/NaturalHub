import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HealthTipsService } from '../health-tips.service';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';
import { IHealthTips, ITips } from '../../../../models/modelsInterface';
import { TipsComponent } from '../tips/tips.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // ✅ Import FormsModule

@Component({
  selector: 'app-health-tips',
  standalone: true,
  imports: [CommonModule, NgbAccordionModule, TipsComponent, FormsModule],
  templateUrl: './health-tips.component.html',
  styleUrl: './health-tips.component.scss',
})
export class HealthTipsComponent implements OnInit {
  healthTips!: IHealthTips[];
  filteredhealthTips!: IHealthTips[];

  tags: string[] = []; // Stores the added tags
  inputValue: string = '';

  // Add a tag when the user presses 'Enter'
  addTag(event: KeyboardEvent): void {
    const value = this.inputValue.trim();
    //console.log(value);
    if (event.key === 'Enter' && value) {
      console.log(value);
      this.healthService.getHealthTipsByName(value).subscribe({
        next: (result) => {
          console.log(result);
          this.filteredhealthTips = result;
        },
      });
    } else {
      this.filteredhealthTips = this.healthTips;
    }
  }

  // Remove a tag when clicking the 'X' button
  removeTag(index: number): void {
    this.tags.splice(index, 1);
  }

  ngOnInit(): void {}
  constructor(private healthService: HealthTipsService) {
    this.healthService.getHealthTips().subscribe({
      next: (result) => {
        this.healthTips = result;
        this.filteredhealthTips = this.healthTips;
      },
    });
  }
}
