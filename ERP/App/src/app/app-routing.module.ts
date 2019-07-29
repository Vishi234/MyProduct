import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContainerComponent } from './container/container.component';
import { GeneralComponent } from './setting/general/general.component';
import { ContainerComponent } from './home/container/container.component';
import { DashboardComponent } from './home/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: ContainerComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'setting/general', component: GeneralComponent },
      { path: 'dashboard', component: DashboardComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
