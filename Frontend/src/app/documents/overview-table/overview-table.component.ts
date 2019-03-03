import { Document } from './../../models/document';
import {merge, of as observableOf} from 'rxjs';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { switchMap, map, catchError, startWith } from 'rxjs/operators';
import { DocumentService } from 'src/app/model-services/document.service';


const ELEMENT_DATA: Document[] = [
  {id: 1, name: 'Fallübersicht'},
  {id: 2, name: 'Fragebogen Kinder'},
  {id: 3, name: 'Testbogen'},
  {id: 4, name: 'Elterngespräch'},
  {id: 5, name: 'Review + Retests'},
];

@Component({
  selector: 'app-overview-table',
  templateUrl: './overview-table.component.html',
  styleUrls: ['./overview-table.component.scss']
})
export class OverviewTableComponent implements OnInit {

  // docTitles: string[] = ['Anamnese', 'Testung', 'Report'];


  displayedColumns: string[] = ['name'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  @ViewChild(MatSort) sort: MatSort;


  constructor(private $router: Router, private $docService: DocumentService) { }

  ngOnInit() {
    this.dataSource.sort = this.sort;
  }

  // initDocuments(): Document[] {
  //   let documents: Document[] = [];

  //   this.docTitles.forEach((docName, index) => {
  //     let doc: Document = {
  //       id: index,
  //       name: docName
  //     };
  //     documents.push(doc);
  //   });
  //   return documents;


  // }

  openDocument ( _id: string, $event: Event ) {
    this.$router.navigate( ['document/', _id]);
  }

}
