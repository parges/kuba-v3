import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  constructor(private $router: Router) { }

  navigate(path: string) {
    this.$router.navigate([path]);
    //  this.router.navigateByURL(['path']);
  }
}
