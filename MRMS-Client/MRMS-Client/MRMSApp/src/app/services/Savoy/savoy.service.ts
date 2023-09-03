import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/Product/Product';
import { SavoyApiUrl } from 'src/app/models/shared/app-constants';

const endPoint : string = "SavoyIceCreams";

@Injectable({
  providedIn: 'root'
})
export class SavoyService {

  constructor(
    private http: HttpClient
  ) { }

  get(): Observable<Product[]> {
    return this.http.get<Product[]>(`${SavoyApiUrl}/${endPoint}/`);
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${SavoyApiUrl}/${endPoint}/`);
  }

  getById(id: number): Observable<Product> {
    return this.http.get<Product>(`${SavoyApiUrl}/${endPoint}/${id}`);
  }
  insert(data: Product): Observable<Product> {
    return this.http.post<Product>(`${SavoyApiUrl}/${endPoint}`, data);
  }
  update(data: Product): Observable<any> {
    return this.http.put<any>(`${SavoyApiUrl}/${endPoint}`, data);
  }
  delete(data: Product): Observable<any> {
    return this.http.delete<any>(`${SavoyApiUrl}/${endPoint}/${data.productId}`);
  }
}
