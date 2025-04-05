import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProducts } from '../../../models/modelsInterface';
import { Observable } from 'rxjs';
import { query } from '@angular/animations';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartService {
  private apiUrl = 'https://localhost:7218/api/products';
  constructor(private http: HttpClient) {}

  getProducts(): Observable<IProducts[]> {
    return this.http.get<IProducts[]>(`${this.apiUrl}`);
  }

  getProduct(id: number): Observable<IProducts> {
    return this.http.get<IProducts>(`${this.apiUrl}/${id}`);
  }
  getProductByName(name: string): Observable<IProducts[]> {
    let params = new HttpParams().set('ProductName', name);

    return this.http.get<IProducts[]>(`${this.apiUrl}/search`, { params });
  }
}
