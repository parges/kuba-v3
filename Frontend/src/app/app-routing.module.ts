import { OverviewTableComponent } from './documents/overview-table/overview-table.component';
import { CustAddComponent } from './customer-edit/cust-add/cust-add.component';
import { CustGetComponent } from './customer-edit/cust-get/cust-get.component';
import { CustListComponent } from './customer-overview/cust-list/cust-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'dash', component: DashboardComponent },
  { path: 'customers', component: CustListComponent},
  { path: 'customers/add', component: CustAddComponent },
  { path: 'customers/:id', component: CustGetComponent },
  { path: 'documents', component: OverviewTableComponent },
  { path: 'document/:id', component: OverviewTableComponent },

  { path: '', redirectTo: '/dash', pathMatch: 'full' },
  { path: '**', component: DashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
