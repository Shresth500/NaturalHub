import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../shopping-cart.service';
import { IProducts } from '../../../../models/modelsInterface';
import { CommonModule } from '@angular/common';
import { ItemsComponent } from '../Items/items/items.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // ✅ Import FormsModule

@Component({
  selector: 'app-shopping-cart',
  standalone: true,
  imports: [CommonModule, ItemsComponent, FormsModule],
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.scss',
})
export class ShoppingCartComponent implements OnInit {
  /*
  cards = [
    {
      id: 1,
      title: 'Card 1',
      description: 'This is card 1',
    },
    {
      id: 2,
      title: 'Card 2',
      description: 'This is card 2',
    },
    {
      id: 3,
      title: 'Card 3',
      description: 'This is card 3',
    },
  ];
  */

  tags: string[] = []; // Stores the added tags
  inputValue: string = '';

  // Add a tag when the user presses 'Enter'
  addTag(event: KeyboardEvent): void {
    const value = this.inputValue.trim();
    //console.log(value);
    if (event.key === 'Enter' && value) {
      console.log(value);
      this.shoppingService.getProductByName(value).subscribe({
        next: (result) => {
          console.log(result);
          this.filteredProducts = result;
        },
      });
    } else {
      this.filteredProducts = this.products;
    }
  }

  // Remove a tag when clicking the 'X' button
  removeTag(index: number): void {
    this.tags.splice(index, 1);
  }

  products: IProducts[] = [];
  filteredProducts: IProducts[] = [];

  ngOnInit(): void {}

  constructor(private shoppingService: ShoppingCartService) {
    this.shoppingService.getProducts().subscribe({
      next: (result) => {
        this.products = result;
        this.filteredProducts = this.products;
        console.log(result);
      },
    });
  }
}
