import { Component } from '@angular/core';
import { StudentInfromation } from './students.model';
import { StudentsService } from './students.service';

@Component({
  selector: 'students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss']
})
export class StudentsComponent {
  data: StudentInfromation[] = <StudentInfromation[]>{};

  constructor(private studentService: StudentsService) {
    this.getData();
  }

  getData() {
    this.studentService.get().subscribe(data => {
      this.data = data;
    });
  }

  getAllSubjects(): string[] {
    const subjectsSet = new Set<string>();

    for (const student of this.data) {
      for (const grade of student.subjectRespectiveGrades) {
        subjectsSet.add(grade.subjectName);
      }
    }

    return Array.from(subjectsSet);
  }

  getStudentGrade(subject: string, studentInfo: StudentInfromation): number | string {
    const grade = studentInfo.subjectRespectiveGrades.find(
      (item) => item.subjectName === subject
    );
    return grade ? grade.respectiveGrade : 'N/A';
  }
}
