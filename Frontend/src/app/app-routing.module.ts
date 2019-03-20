import { LoginComponent } from './login/login.component';
import { AuthGuard } from './../../libs/authentication/src/lib/guards/auth.guard';
import { Uebersicht00Component } from './documents/uebersicht/uebersicht00.component';
import { Report03Component } from './documents/report/report03.component';
import { Testung02Component } from './documents/testung/testung02.component';
import { Anamnese01Component } from './documents/anamnese/anamnese01.component';
import { OverviewTableComponent } from './documents/overview-table/overview-table.component';
import { CustAddComponent } from './customer-edit/cust-add/cust-add.component';
import { CustGetComponent } from './customer-edit/cust-get/cust-get.component';
import { CustListComponent } from './customer-overview/cust-list/cust-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'customers',
    component: CustListComponent,
    canActivate: [AuthGuard]
  },
  { path: 'customers/add', component: CustAddComponent },
  { path: 'customers/:id', component: CustGetComponent },
  { path: 'documents', component: OverviewTableComponent, canActivate: [AuthGuard] },
  { path: 'document/1', component: Uebersicht00Component, canActivate: [AuthGuard]  },
  { path: 'document/2', component: Anamnese01Component, canActivate: [AuthGuard]  },
  { path: 'document/3', component: Testung02Component, canActivate: [AuthGuard]  },
  { path: 'document/4', component: Report03Component, canActivate: [AuthGuard]  },
  {
    path: 'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,
    {
      preloadingStrategy: PreloadAllModules,
      // enableTracing: !environment.production
    })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
