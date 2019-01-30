import { FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { CustomerService } from './../../customer/customer.service';
import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/customer/customer';

import { MAT_DATE_LOCALE} from '@angular/material/core';


@Component({
  selector: 'app-cust-get',
  templateUrl: './cust-get.component.html',
  styleUrls: ['./cust-get.component.scss'],
  providers: [
    // The locale would typically be provided on the root module of your application. We do it at
    // the component level here, due to limitations of our example generation script.
    {provide: MAT_DATE_LOCALE, useValue: 'de-DE'},

  ],
})
export class CustGetComponent implements OnInit, OnDestroy {


  id: number;
  private sub: any;
  activeCustomer: Customer;
  tempCustomer: Customer;

  regiForm: FormGroup;
  formBuilder: FormBuilder;

  constructor(private route: ActivatedRoute, private $router: Router, private $customer: CustomerService, private fb: FormBuilder) {
    this.formBuilder = fb;
    this.regiForm = this.formBuilder.group({
      'id' : ['1'],
      'firstname' : ['2', Validators.required],
      'lastname' : ['3', Validators.required],
      'tele' : ['3', Validators.required],
      'birthday' : ['']
    });
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      // In a real app: dispatch action to load the details here.
      this.$customer.getCustomerByID(this.id).then(cust => {
        this.activeCustomer = cust;
        // To initialize FormGroup
        this.regiForm.setValue({
          id: this.activeCustomer.id,
          firstname: this.activeCustomer.firstname,
          lastname: this.activeCustomer.lastname,
          tele: this.activeCustomer.tele,
          birthday: this.activeCustomer.birthday
        });
      });
     });

  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  // Executed When Form Is Submitted
  onFormSubmit() {
    // Make sure to create a deep copy of the form-model
    const result: Customer = Object.assign({}, this.regiForm.value);
    this.$customer.updateCustomer(result).then(customer => {
        this.activeCustomer = customer;
    });

  }

}
