import { CustomerService } from './../../customer/customer.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/customer/customer';

@Component({
  selector: 'app-cust-get',
  templateUrl: './cust-get.component.html',
  styleUrls: ['./cust-get.component.scss']
})
export class CustGetComponent implements OnInit, OnDestroy {

  id: number;
  private sub: any;
  activeCustomer: Customer;

  constructor(private route: ActivatedRoute, private $customer: CustomerService) {
   }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      // In a real app: dispatch action to load the details here.
      this.$customer.getCustomerByID(this.id).then(cust => {
        this.activeCustomer = cust;
      });
     });

  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  saveCustomer() {
    this.$customer.updateCustomer(this.activeCustomer).then( _ => {
      alert('User gespeichert!');
    })
  }

}
