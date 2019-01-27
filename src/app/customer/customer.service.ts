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
    // const params = new HttpParams()
    // .set('_sort', sort)
    // .set('_order', order)
    // .set('_page', (page + 1).toString())
    // .set('_observe', 'response');

    // return this.$http.get<Customer[]>( environment.endpoint, {params})
    //            .pipe(
    //              tap( next => {
    //                this.customerList = next;
    //               //  if ( !! this.selectedUser ) {
    //               //   this.selectedUser = this.userList.find( value => value.id === this.selectedUser.id );
    //                }
    //              )
    //            )
    //             .toPromise();

    //           //  .subscribe((res: Response) => {
    //           //   console.log(res.headers);
    //           //   // you can assign the value to any variable here
    //           // });
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
}



