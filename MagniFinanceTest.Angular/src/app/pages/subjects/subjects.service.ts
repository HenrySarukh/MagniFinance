import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { SubjectInformation } from './subjects.model';

@Injectable({
  providedIn: 'root',
})
export class SubjectsService {
  constructor(private httpClient: HttpClient) { }

  apiUrl = environment.apiUrl;
  route = '/Subject/Info';

  get(): Observable<SubjectInformation[]> {
    return this.httpClient.get<SubjectInformation[]>(this.apiUrl + this.route);
  }
}
