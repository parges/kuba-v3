
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { tap, map, catchError } from 'rxjs/operators';
import { Customer } from './customer';
import { of, Observable } from 'rxjs';

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

  getCustomerByID ( id: number ): Promise<Customer> {
    return this.$http.get<Customer>( environment.endpoint + '/' + id  )
               .toPromise();
  }

  updateCustomer ( cust: Customer ): Promise<Customer> {
    return this.$http.put<Customer>( environment.endpoint + '/' + cust.id, cust )
               .toPromise();
  }
  updateCustomerFormData ( cust: FormData ): Promise<Customer> {
    return this.$http.put<Customer>( environment.endpoint + '/' + cust.get("id"), cust )
              .pipe(catchError(this.handleError<Customer>(`updateUser`)))
               .toPromise();
  }

  getImageByFilename ( patientId: number ): Observable<Blob> {
    return this.$http.get( environment.globalEndpoint + 'image/' + patientId, { responseType: 'blob' } );
  }

  addCustomer ( cust: Customer ): Promise<Customer> {
    return this.$http.post<Customer>( environment.endpoint, cust )
               .toPromise();
  }

  delCustomer ( cust: Customer ): Promise<Customer> {
    return this.$http.delete<any>( environment.endpoint + '/' + cust.id)
               .toPromise();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
}

  uploadImage (upFile: File, userId: number) {
    // this.http is the injected HttpClient
    this.$http.post(environment.endpoint + '/ImageUpload', {upFile, userId}, {
      // reportProgress: true,
      // observe: 'events'
    }).subscribe(event => {
        console.log(event); // handle event here
      });
  }
}



