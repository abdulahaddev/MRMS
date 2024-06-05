import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AgencySyndicate } from '../../models/AgencySection/agency-syndicate';
import { apiUrl } from '../../models/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class AgencySyndicateService {

  constructor(
    private http: HttpClient
  ) { }
  get(): Observable<AgencySyndicate[]> {
    return this.http.get<AgencySyndicate[]>(`${apiUrl}/AgencySyndicate`);
  }

  getById(id: number): Observable<AgencySyndicate> {
    return this.http.get<AgencySyndicate>(`${apiUrl}/AgencySyndicate/${id}`);
  }
  insert(data: AgencySyndicate): Observable<AgencySyndicate> {
    return this.http.post<AgencySyndicate>(`${apiUrl}/AgencySyndicate`, data);
  }
  update(data: AgencySyndicate): Observable<any> {
    return this.http.put<any>(`${apiUrl}/AgencySyndicate/${data.AgencySyndicateId}`, data);
  }
  delete(data: AgencySyndicate): Observable<any> {
    return this.http.delete<any>(`${apiUrl}/AgencySyndicate/${data.AgencySyndicateId}`);
  }
}
