import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustAddComponent } from './cust-add/cust-add.component';
import { CustGetComponent } from './cust-get/cust-get.component';
import { MatInputModule, MatFormFieldModule, MatOptionModule, MatSelectModule, MatButtonModule } from '@angular/material';

@NgModule({
  declarations: [CustAddComponent, CustGetComponent],
  imports: [
    CommonModule,
    MatInputModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatButtonModule
  ],
  exports: [CustAddComponent, CustGetComponent]
})
export class CustomerEditModule { }
