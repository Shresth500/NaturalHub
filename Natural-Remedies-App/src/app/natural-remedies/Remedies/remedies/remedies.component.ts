import { Component, OnInit } from '@angular/core';
import { RemediesService } from '../remedies.service';
import { IRemedies } from '../../../../models/modelsInterface';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { RemedyComponent } from '../../remedy/remedy.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // ✅ Import FormsModule

@Component({
  selector: 'app-remedies',
  standalone: true,
  imports: [NgbAccordionModule, CommonModule, RemedyComponent, FormsModule],
  templateUrl: './remedies.component.html',
  styleUrl: './remedies.component.scss',
})
export class RemediesComponent implements OnInit {
  tags: string[] = []; // Stores the added tags
  inputValue: string = '';

  // Add a tag when the user presses 'Enter'
  addTag(event: KeyboardEvent): void {
    const value = this.inputValue.trim();
    //console.log(value);
    if (event.key === 'Enter' && value) {
      console.log(value);
      this.remediesService.getRemediesByName(value).subscribe({
        next: (result) => {
          console.log(result);
          this.filteredremediesData = result;
        },
      });
    } else {
      this.filteredremediesData = this.remediesData;
    }
  }

  // Remove a tag when clicking the 'X' button
  removeTag(index: number): void {
    this.tags.splice(index, 1);
  }

  remediesData: IRemedies[] = [];
  filteredremediesData: IRemedies[] = [];

  ngOnInit(): void {
    // throw new Error('Method not implemented.');
    this.remediesService.getRemedies().subscribe({
      next: (result) => {
        this.remediesData = result;
        this.filteredremediesData = this.remediesData;
        console.log(result);
      },
    });
  }

  constructor(private remediesService: RemediesService) {}
}
