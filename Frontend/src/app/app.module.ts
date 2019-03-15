import { MaterialModule } from './material-module';
import { DocumentsModule } from './documents/documents.module';
import { NoCachInterceptorService } from './interceptor/httpconfig.interceptor';
import { CustomerEditModule } from './customer-edit/customer-edit.module';
import { CustomerOverviewModule } from './customer-overview/customer-overview.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

// tslint:disable-next-line:max-line-length
import {MatToolbarModule, MAT_DIALOG_DEFAULT_OPTIONS} from '@angular/material';
import { A11yModule } from '@angular/cdk/a11y';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UploadComponent } from './utils/upload/upload.component';
import { SnackbarGenericComponent } from './utils/snackbar-generic/snackbar-generic.component';
import { PatientAutocompleteDialog } from './utils/patient-external-dialog/patient-external-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    SnackbarGenericComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    DashboardModule,
    CustomerOverviewModule,
    CustomerEditModule,
    DocumentsModule,
    MatToolbarModule,
    CdkTableModule,
    ScrollingModule
  ],
  providers   : [
  {
    provide : HTTP_INTERCEPTORS,
    useClass: NoCachInterceptorService, multi: true
  },
  {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
