import { Component } from '@angular/core';
import { SubjectInformation } from './subjects.model';
import { SubjectsService } from './subjects.service';

@Component({
  selector: 'subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.scss']
})
export class SubjectsComponent {
  data: SubjectInformation[] = <SubjectInformation[]>{};

  constructor(private subjectsService: SubjectsService) {
    this.getData();
  }

  getData() {
    this.subjectsService.get().subscribe(data => { 
      this.data = data;
    });
  }
}
