import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Agency } from '../../models/AgencySection/agency';
import { apiUrl } from '../../models/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class AgencyService {

  constructor(
    private http: HttpClient
  ) { }
  get(): Observable<Agency[]> {
    return this.http.get<Agency[]>(`${apiUrl}/Agency`);
  }

  getById(id: number): Observable<Agency> {
    return this.http.get<Agency>(`${apiUrl}/Agency/${id}`);
  }
  insert(data: Agency): Observable<Agency> {
    return this.http.post<Agency>(`${apiUrl}/Agency`, data);
  }
  update(data: Agency): Observable<any> {
    return this.http.put<any>(`${apiUrl}/Agency`, data);
  }
  delete(data: Agency): Observable<any> {
    return this.http.delete<any>(`${apiUrl}/Agency/${data.agencyId}`);
  }
}
