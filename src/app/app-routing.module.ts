import { CustGetComponent } from './customer-edit/cust-get/cust-get.component';
import { CustAddComponent } from './customer-edit/cust-add/cust-add.component';
import { CustListComponent } from './customer-overview/cust-list/cust-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'dash', component: DashboardComponent },
  { path: 'customers', component: CustListComponent },
  { path: 'customers/:id', component: CustGetComponent  },
  { path: 'customers/add', component: CustAddComponent},
  { path: '', redirectTo: '/dash', pathMatch: 'full' },
  { path: '**', component: DashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
