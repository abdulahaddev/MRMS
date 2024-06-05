import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FileTypes } from 'src/app/models/common/file-types';
import { apiUrl } from 'src/app/models/shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor(
    private http: HttpClient
  ) { }

  get(): Observable<FileTypes[]> {
    return this.http.get<FileTypes[]>(`${apiUrl}/FileTypes`);
  }
}
