import { Component, OnInit } from '@angular/core';
import { IProducts } from '../../../../models/modelsInterface';
import { ShoppingCartService } from '../../../natural-remedies/ShoppingCart/shopping-cart.service';
import { ActivatedRoute } from '@angular/router';
import { ProfileService } from '../../../User/Profile/profile.service';
import { IAddProduct } from '../../../../models/modelsInterface';

@Component({
  selector: 'app-items-data',
  standalone: true,
  imports: [],
  templateUrl: './items-data.component.html',
  styleUrl: './items-data.component.scss',
})
export class ItemsDataComponent implements OnInit {
  ProductDetails!: IProducts;
  productId!: number;

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('productid');
    if (id == null) return;
    this.productId = Number.parseInt(id);
    this.productService.getProduct(this.productId).subscribe({
      next: (result) => {
        this.ProductDetails = result;
        console.log(result);
      },
    });
  }

  constructor(
    private productService: ShoppingCartService,
    private route: ActivatedRoute,
    private userProductCatalog: ProfileService
  ) {}

  addToCart() {
    let data: IAddProduct = {} as IAddProduct;
    data.productId = this.productId;
    data.quantity = 1;
    console.log(data);
    this.userProductCatalog.addItemsToCart(data).subscribe({
      next: (result) => {
        alert(`${this.ProductDetails.name} is added to the cart`);
        console.log(result);
      },
    });
  }
  BuyItem() {
    let data: IAddProduct = {} as IAddProduct;
    data.productId = this.productId;
    data.quantity = 1;
    console.log(data);
    this.userProductCatalog.buyItems(data).subscribe({
      next: (result) => {
        alert(`${this.ProductDetails.name} is ordered`);
        console.log(result);
      },
    });
  }
}
