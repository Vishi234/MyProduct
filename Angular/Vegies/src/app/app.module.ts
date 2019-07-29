import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {
  MatFormFieldModule, MatCardModule, MatSlideToggleModule, MatInputModule, MatListModule, MatStepperModule,
  MatExpansionModule, MatDialogModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher, MatCheckboxModule, MatButtonModule,
  MatSelectModule, MatIconModule, MatPaginator, MatTableModule, MatTooltipModule, MatMenuModule, MatToolbarModule, MatButtonToggleModule,
  MatTabsModule, MatSidenavModule, MatOptionModule
} from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MDBBootstrapModule, IconsModule, CheckboxModule } from 'angular-bootstrap-md';
import {NgUikitModule} from 'ng-uikit';
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
import{VendorContainerComponent} from './vendor/container/container.component'

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
    VendorContainerComponent
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
    NgUikitModule,
    MatDialogModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    MatIconModule,
    MatExpansionModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[ForgotPasswordComponent]
})
export class AppModule { }
