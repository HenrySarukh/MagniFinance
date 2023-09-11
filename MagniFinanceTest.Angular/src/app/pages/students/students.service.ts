import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { StudentInfromation } from './students.model';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  constructor(private httpClient: HttpClient) { }

  apiUrl = environment.apiUrl;
  route = '/Student/Info';

  get(): Observable<StudentInfromation[]> {
    return this.httpClient.get<StudentInfromation[]>(this.apiUrl + this.route);
  }
}
