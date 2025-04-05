import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  IAddProduct,
  IProducts,
  IUserProductCatalog,
} from '../../../models/modelsInterface';

@Injectable({
  providedIn: 'root',
})
export class ProfileService {
  private apiUrl = 'https://localhost:7218/api/UserProduct';

  constructor(private http: HttpClient) {}
  getUser(userName: string): Observable<IUserProductCatalog> {
    let params = new HttpParams().set('userName', userName);
    return this.http.get<IUserProductCatalog>(`${this.apiUrl}`, { params });
  }

  postFromCarts() {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<IUserProductCatalog>(
      `${this.apiUrl}/checkout`,
      {},
      { headers }
    );
  }
  buyItems(Items: IAddProduct): Observable<IUserProductCatalog> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<IUserProductCatalog>(`${this.apiUrl}/buy`, Items, {
      headers,
    });
  }

  addItemsToCart(Items: IAddProduct): Observable<IUserProductCatalog> {
    console.log(Items);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(`${this.apiUrl}/addToCart`, Items, { headers });
  }
}
