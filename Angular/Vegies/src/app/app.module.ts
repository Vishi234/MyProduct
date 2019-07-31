import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {
  MatFormFieldModule, MatInputModule, MatListModule,MatExpansionModule, MatDialogModule,
  MatSelectModule, MatIconModule, MatToolbarModule,MatSidenavModule, MatOptionModule,MatButtonToggleModule
} from '@angular/material';

import { DateRangePickerModule } from '@syncfusion/ej2-angular-calendars';
import { GridModule} from '@syncfusion/ej2-angular-grids';
import { PageService, SortService, FilterService, GroupService } from '@syncfusion/ej2-angular-grids';
import { CheckBoxModule } from '@syncfusion/ej2-angular-buttons';

import { Ng2CarouselamosModule } from 'ng2-carouselamos';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MDBBootstrapModule, IconsModule, CheckboxModule } from 'angular-bootstrap-md';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { ContainerComponent } from './container/container.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { DashboardComponent } from './vendor/dashboard/dashboard.component';
import{VendorContainerComponent} from './vendor/container/container.component';
import { ConfigurationComponent } from './vendor/configuration/configuration.component'

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ContainerComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    DashboardComponent,
    VendorContainerComponent,
    ConfigurationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MDBBootstrapModule.forRoot(),
    IconsModule,
    CheckboxModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    MatIconModule,
    MatExpansionModule,
    DateRangePickerModule,
    GridModule,
    CheckBoxModule,
    Ng2CarouselamosModule,
    MatButtonToggleModule
  ],
  providers: [PageService, SortService, FilterService, GroupService],
  bootstrap: [AppComponent],
  entryComponents:[ForgotPasswordComponent,ConfigurationComponent]
})
export class AppModule { }
