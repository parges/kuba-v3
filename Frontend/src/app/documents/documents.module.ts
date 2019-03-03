import { MaterialModule } from './../material-module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Uebersicht00Component, DialogExampleDialog } from './uebersicht/uebersicht00.component';
import { Report03Component } from './report/report03.component';
import { Testung02Component } from './testung/testung02.component';
import { Anamnese01Component } from './anamnese/anamnese01.component';
// tslint:disable-next-line:max-line-length
import { MatInputModule, MatFormFieldModule, MatOptionModule, MatSelectModule, MatButtonModule, MatDatepickerModule, MatNativeDateModule, MatTableModule, MatSortModule, MatExpansionModule, MatCheckboxModule, MatDialogModule, MatAutocompleteModule } from '@angular/material';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OverviewTableComponent } from './overview-table/overview-table.component';

@NgModule({
  declarations: [OverviewTableComponent, Anamnese01Component, Testung02Component, Report03Component, Uebersicht00Component, DialogExampleDialog],
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
  entryComponents: [DialogExampleDialog]

})
export class DocumentsModule { }
