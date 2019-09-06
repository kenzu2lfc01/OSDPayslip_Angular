import { NgModule } from '@angular/core';
import { RequestComponent } from './request/request.component';
import { PaylipsComponent } from './payslips/paylips.component';
import { HomeComponent } from './home/home.component';

import { RouterModule, Routes } from '@angular/router';
import {APP_BASE_HREF} from '@angular/common';
const routes: Routes = [
  { path: 'homes', component: HomeComponent },
  { path: 'requests', component: RequestComponent },
  { path: 'payslips',  children: [
    {
      path: ':Id',
      component: PaylipsComponent
    }
  ] }
];


@NgModule({
  imports: [RouterModule.forRoot(routes),RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [{provide: APP_BASE_HREF, useValue : '/' }]
})
export class AppRoutingModule { }
export  const appRoutingModule = [PaylipsComponent,RequestComponent]