import { MaterialModule } from './../../../libs/material/src/lib/material.module';
import { PatientAutocompleteDialog } from './../utils/patient-external-dialog/patient-external-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Uebersicht00Component } from './uebersicht/uebersicht00.component';
import { Report03Component } from './report/report03.component';
import { Testung02Component } from './testung/testung02.component';
import { Anamnese01Component } from './anamnese/anamnese01.component';
import {MatTableModule, MatSortModule, MatExpansionModule} from '@angular/material';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OverviewTableComponent } from './overview-table/overview-table.component';
import { TestungTaskComponent } from './testung/testung-task/testung-task.component';

@NgModule({
  declarations: [OverviewTableComponent, Anamnese01Component, Testung02Component, Report03Component, Uebersicht00Component, TestungTaskComponent, PatientAutocompleteDialog],
  imports: [
    CommonModule,
    MatTableModule,
    MatSortModule,
    MatExpansionModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  exports: [
  ],
  entryComponents: [PatientAutocompleteDialog],

})
export class DocumentsModule { }
