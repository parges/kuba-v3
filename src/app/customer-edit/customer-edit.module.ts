import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustAddComponent } from './cust-add/cust-add.component';

@NgModule({
  declarations: [CustAddComponent],
  imports: [
    CommonModule
  ],
  exports: [CustAddComponent]
})
export class CustomerEditModule { }
