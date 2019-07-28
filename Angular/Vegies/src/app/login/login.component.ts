import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ForgotPasswordComponent } from '../forgot-password/forgot-password.component';
import { MatDialog, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(public dialog: MatDialog) { }

  showModal() {
    this.dialog.open(ForgotPasswordComponent, { disableClose: true });
  }
  ngOnInit() {

  }

}
