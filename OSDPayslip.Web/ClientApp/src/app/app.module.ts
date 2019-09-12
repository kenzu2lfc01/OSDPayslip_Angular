import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { MenuPayslipComponent } from './menu-payslip/menu-payslip.component';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { HttpClientModule } from "@angular/common/http"
import { MatTableModule } from '@angular/material/table';

import {
	IgxButtonModule,
	IgxIconModule,
	IgxLayoutModule,
	IgxNavigationDrawerModule,
	IgxRadioModule,
	IgxRippleModule,
	IgxSwitchModule,
	IgxToggleModule
} from "igniteui-angular";
import { AppRoutingModule, appRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { RequestDetailsService } from './shared/request/request-details.service';
import { CreateRequestComponent } from './request/create-request/create-request.component';
import { MatDialogModule, MatButtonModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatToolbarModule, MatSidenavModule, MatIconModule, MatListModule, MatStepperModule } from '@angular/material';
import { PayslipDetailsComponent } from './payslips/payslip-details/payslip-details.component';
@NgModule({
	declarations: [
		AppComponent,
		MenuPayslipComponent,
		appRoutingModule,
		HomeComponent,
		CreateRequestComponent,
		PayslipDetailsComponent,
	],
	imports: [
		BrowserModule,
		HttpClientModule,
		BrowserAnimationsModule,
		FormsModule,
		IgxButtonModule,
		IgxIconModule,
		IgxLayoutModule,
		IgxNavigationDrawerModule,
		IgxRadioModule,
		IgxRippleModule,
		IgxSwitchModule,
		IgxToggleModule,
		AppRoutingModule,
		MatDialogModule,
		MatTableModule,
		MatToolbarModule,
		MatButtonModule,
		MatSidenavModule,
		MatIconModule,
		MatListModule,
		MatStepperModule,
		MatInputModule
	],
	exports: [
		MatButtonModule,
		MatFormFieldModule,
		MatInputModule,
		MatRippleModule,
		MatToolbarModule,
		MatButtonModule,
		MatSidenavModule,
		MatIconModule,
		MatListModule,
		MatStepperModule,
		MatInputModule
	],
	providers: [RequestDetailsService],
	bootstrap: [AppComponent],
	entryComponents: [CreateRequestComponent]
})
export class AppModule { }
