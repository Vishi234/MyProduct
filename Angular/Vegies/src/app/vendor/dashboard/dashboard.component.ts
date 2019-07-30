import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public start: Date = new Date ("10-Jul-2017"); 
  public end: Date = new Date ("11-Aug-2017");
  constructor() { }

  ngOnInit() {
  }

}
