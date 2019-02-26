import { Document } from './../../models/document';
import {merge, of as observableOf} from 'rxjs';
import { MatPaginator, MatSort } from '@angular/material';
import { Router } from '@angular/router';
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { switchMap, map, catchError, startWith } from 'rxjs/operators';
import { DocumentService } from 'src/app/model-services/document.service';

@Component({
  selector: 'app-overview-table',
  templateUrl: './overview-table.component.html',
  styleUrls: ['./overview-table.component.scss']
})
export class OverviewTableComponent implements AfterViewInit {

  displayedColumns: string[] = ['name'];
  dataSource: Document[] = [];

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;


  constructor(private $router: Router, private $docService: DocumentService) { }

  ngAfterViewInit() {

    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this.$docService.getDocuments(this.sort.active, this.sort.direction, this.paginator.pageIndex);
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = this.$docService.totalCount;
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

  openDocument ( _id: string, $event: Event ) {
    this.$router.navigate( ['document/', _id]);
  }

}
