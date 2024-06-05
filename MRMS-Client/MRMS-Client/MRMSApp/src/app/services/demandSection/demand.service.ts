import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Demand } from '../../models/demandSection/demand';
import { apiUrl } from '../../models/shared/app-constants';
import { FileInfo } from 'src/app/models/common/file-info';
import { DemandFile } from 'src/app/models/demandSection/demand-file';

@Injectable({
  providedIn: 'root'
})
export class DemandService {

  constructor(
    private http: HttpClient
  ) { }
  get(): Observable<Demand[]> {
    return this.http.get<Demand[]>(`${apiUrl}/Demands`);
  }

  getById(id: number): Observable<Demand> {
    return this.http.get<Demand>(`${apiUrl}/Demands/${id}`);
  }
  insert(data: Demand): Observable<Demand> {
    return this.http.post<Demand>(`${apiUrl}/Demands`, data);
  }
  update(data: Demand): Observable<any> {
    return this.http.put<any>(`${apiUrl}/Demands/${data.demandId}`, data);
  }
  delete(data: Demand): Observable<any> {
    return this.http.delete<any>(`${apiUrl}/Demands/${data.demandId}`);
  }

  // ---------------------------
  getFiles(): Observable<DemandFile[]> {
    return this.http.get<DemandFile[]>(`${apiUrl}/DemadFiles`);
  }

  getFileById(id: number): Observable<DemandFile> {
    return this.http.get<DemandFile>(`${apiUrl}/DemadFiles/${id}`);
  }

  deleteFile(data: FileInfo): Observable<DemandFile> {
    return this.http.delete<any>(`${apiUrl}/DemadFiles/${data.fileId}`);
  }
}
