import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CoursesComponent } from './pages/courses/courses.component';
import { SubjectsComponent } from './pages/subjects/subjects.component';
import { StudentsComponent } from './pages/students/students.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: `/courses`,
    pathMatch: 'full'
  },
  {
    path: 'courses',
    component: CoursesComponent,
  },
  {
    path: 'subjects',
    component: SubjectsComponent,
  },
  {
    path: 'students',
    component: StudentsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
