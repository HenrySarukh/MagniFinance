import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CourseInformation } from './courses.model';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(private httpClient: HttpClient) { }

  apiUrl = environment.apiUrl;
  route = '/Course/Info';

  get(): Observable<CourseInformation[]> {
    return this.httpClient.get<CourseInformation[]>(this.apiUrl + this.route);
  }
}
