import { Customer } from './customer';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { tap, map } from 'rxjs/operators';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  customerList: Customer[] = [
    { firstname: 'saban', lastname: 'uenlue', tele: '1' },
    { firstname: 'peter', lastname: 'müller', tele: '1' }
];

  totalCount: number;

  constructor(private $http: HttpClient) { }

  getUsers (sort: string, order: string, page: number): Promise<Customer[]> {

    const params = new HttpParams()
    .set('_sort', sort)
    .set('_order', order)
    .set('_page', (page + 1).toString())
    .set('_observe', 'response');
    // tslint:disable-next-line:max-line-length
    return this.$http.get(environment.endpoint, {observe: 'response', params})
    .pipe(
      tap(next => {
        this.customerList = this.extractData(next);
        this.totalCount = +next.headers.get('X-Total-Count');
      })
    )
        .toPromise()
        .then(this.extractData);
  }
  extractData(res: HttpResponse<Object>) {
    const array = new Array();
    let key, count = 0;
    // tslint:disable-next-line:forin
    for (key in res.body) {
        array.push(res.body[count++]);
    }
    // this.totalCount = +res.headers.get('X-Total-Count');
    return array;
  }

  getCustomerByID ( id ): Promise<Customer> {
    return this.$http.get<Customer>( environment.endpoint + '/' + id  )
               .toPromise();
  }

  updateCustomer ( customer: Customer ): Promise<Customer> {
    return this.$http.put<Customer>( environment.endpoint + '/' + customer.id, customer  )
              //  .pipe(
              //    tap( next => this.getUser() )
              //  )
               .toPromise();
}

}



