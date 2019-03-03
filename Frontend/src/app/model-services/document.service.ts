import { Document } from './../models/document';
import { tap } from 'rxjs/operators';
import { environment } from './../../environments/environment';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UebersichtModel } from '../documents/uebersicht/ubersichtModel';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  List: Document[] = [
    { name: 'Anamnese' },
    { name: 'Testung'}
];

  totalCount: number;

  constructor(private $http: HttpClient) { }

  getUebersichtForPatient ( userId: number ): Promise<UebersichtModel> {
    return this.$http.get<UebersichtModel>( environment.endpoint + '/' + userId + '/documents'  )
               .toPromise();
  }

  // getDocuments(sort: string, order: string, page: number): Promise<Document[]> {
  //   const params = new HttpParams()
  //   .set('_sort', sort)
  //   .set('_order', order)
  //   .set('_page', (page + 1).toString())
  //   .set('_observe', 'response');
  //   // tslint:disable-next-line:max-line-length
  //   return this.$http.get(environment.globalEndpoint + 'document', {observe: 'response', params})
  //   .pipe(
  //     tap(next => {
  //       this.List = this.extractData(next);
  //       this.totalCount = +next.headers.get('X-Total-Count');
  //     })
  //   )
  //       .toPromise()
  //       .then(this.extractData);
  // }

  // extractData(res: HttpResponse<Object>) {
  //   const array = new Array();
  //   let key, count = 0;
  //   // tslint:disable-next-line:forin
  //   for (key in res.body) {
  //       array.push(res.body[count++]);
  //   }
  //   // this.totalCount = +res.headers.get('X-Total-Count');
  //   return array;
  // }
}
