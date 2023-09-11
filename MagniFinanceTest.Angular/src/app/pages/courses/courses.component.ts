import { Component } from '@angular/core';
import { CourseInformation } from './courses.model';
import { CoursesService } from './courses.service';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent {
  data: CourseInformation[] = <CourseInformation[]>{};

  constructor(private coursesService: CoursesService) {
    this.getData();
  }

  getData() {
    this.coursesService.get().subscribe(data => { 
      this.data = data;
    });
  }
}
