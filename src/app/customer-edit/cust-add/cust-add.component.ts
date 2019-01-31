import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { CustomerService } from './../../customer/customer.service';
import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/customer/customer';

import { MAT_DATE_LOCALE} from '@angular/material/core';


@Component({
  selector: 'app-cust-add',
  templateUrl: './cust-add.component.html',
  styleUrls: ['./cust-add.component.scss'],
  providers: [
    // The locale would typically be provided on the root module of your application. We do it at
    // the component level here, due to limitations of our example generation script.
    {provide: MAT_DATE_LOCALE, useValue: 'de-DE'},

  ],
})
export class CustAddComponent {

  addCustForm: FormGroup;

  constructor(private $router: Router, private $customer: CustomerService, private fb: FormBuilder) {
    this.addCustForm = this.fb.group({
      'id' : [''],
      'firstname' : ['', Validators.required],
      'lastname' : ['', Validators.required],
      'tele' : ['', Validators.required],
      'birthday' : ['']
    });
   }

  onFormSubmit() {
    const result: Customer = Object.assign({}, this.addCustForm.value);
    this.$customer.addCustomer(result).catch(
      err => console.error(err)
    ).finally(() => {
      this.$router.navigate(['customers']);
    });

  }

}
