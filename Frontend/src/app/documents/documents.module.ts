import { MatSortModule, MatPaginatorModule, MatTableModule, MatProgressSpinnerModule } from '@angular/material';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OverviewTableComponent } from './overview-table/overview-table.component';

@NgModule({
  declarations: [OverviewTableComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatProgressSpinnerModule
  ],
  exports: [
    MatTableModule,
    MatPaginatorModule,
    MatSortModule
  ]
})
export class DocumentsModule { }
