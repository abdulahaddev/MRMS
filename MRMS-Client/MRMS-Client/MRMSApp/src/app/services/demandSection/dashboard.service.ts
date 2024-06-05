import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dashboard } from '../../models/demandSection/dashboard';
import { apiUrl } from '../../models/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(
    private http: HttpClient
  ) { }
  get(): Observable<Dashboard> {
    return this.http.get<Dashboard>(`${apiUrl}/Dashboard`);
  }
}
