import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Application } from '../../models/applicationSection/application';
import { apiUrl } from '../../models/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  constructor(
    private http: HttpClient
  ) { }
  get(): Observable<Application[]> {
    return this.http.get<Application[]>(`${apiUrl}/Applications`);
  }

  getById(id: number): Observable<Application> {
    return this.http.get<Application>(`${apiUrl}/Applications/${id}`);
  }
  insert(data: FormData): Observable<Application> {
    return this.http.post<Application>(`${apiUrl}/Applications`, data);
  }
  update(data: FormData): Observable<any> {
    return this.http.put<any>(`${apiUrl}/Applications`, data);
  }
  delete(data: Application): Observable<any> {
    return this.http.delete<any>(`${apiUrl}/Applications/${data.applicationId}`);
  }
}
