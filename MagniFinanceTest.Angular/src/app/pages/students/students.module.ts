import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StudentsComponent } from './students.component';

@NgModule({
  declarations: [
    StudentsComponent,
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class StudentsModule { }
