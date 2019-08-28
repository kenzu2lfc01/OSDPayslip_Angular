import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuPayslipComponent } from './menu-payslip/menu-payslip.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuPayslipComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
