import { CustomerService } from './../../customer/customer.service';
import { Customer } from 'src/app/customer/customer';
import {Component, ViewChild, AfterViewInit, HostListener} from '@angular/core';
import {MatPaginator, MatSort} from '@angular/material';
import {merge, of as observableOf} from 'rxjs';
import {catchError, map, startWith, switchMap} from 'rxjs/operators';
import { Router } from '@angular/router';


@Component({
  selector: 'app-cust-list',
  templateUrl: './cust-list.component.html',
  styleUrls: ['./cust-list.component.scss']
})
export class CustListComponent implements AfterViewInit {

  customerService: CustomerService;
  displayedColumns: string[] = ['firstname', 'lastname', 'tele'];
  dataSource: Customer[] = [];

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private $customer: CustomerService, private $router: Router  ) {
    this.customerService = $customer;
  }

  ngAfterViewInit() {
    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.$customer.getUsers(this.sort.active, this.sort.direction, this.paginator.pageIndex);
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = this.$customer.totalCount;
          return data;
        }
        ),
        catchError(() => {
          this.isLoadingResults = false;
          this.isRateLimitReached = true;
          return observableOf([]);
        })
      ).subscribe(resp => {
        this.dataSource = resp;
      });

  }

  showCustomerDetails ( _id: string, $event: Event ) {
    this.$router.navigate( ['customers/', _id]);
  }
}
