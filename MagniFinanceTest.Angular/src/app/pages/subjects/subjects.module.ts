import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SubjectsComponent } from './subjects.component';

@NgModule({
  declarations: [
    SubjectsComponent,
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class SubjectsModule { }
