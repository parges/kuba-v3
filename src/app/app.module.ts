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
import {MatToolbarModule, MatIconModule, MatSortModule, MatPaginatorModule, MatTableModule, MatAutocompleteModule, MatBadgeModule, MatBottomSheetModule, MatButtonModule, MatButtonToggleModule, MatCardModule, MatCheckboxModule, MatChipsModule, MatStepperModule, MatDatepickerModule, MatDialogModule, MatDividerModule, MatExpansionModule, MatGridListModule, MatInputModule, MatListModule, MatMenuModule, MatNativeDateModule, MatProgressBarModule, MatProgressSpinnerModule, MatRadioModule, MatRippleModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSlideToggleModule, MatSnackBarModule, MatTabsModule, MatTooltipModule, MatTreeModule} from '@angular/material';
import { A11yModule } from '@angular/cdk/a11y';
import { CdkTableModule } from '@angular/cdk/table';
import { CdkTreeModule } from '@angular/cdk/tree';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UploadComponent } from './utils/upload/upload.component';


@NgModule({
  declarations: [
    AppComponent
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
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
