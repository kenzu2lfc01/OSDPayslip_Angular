import { Component, OnInit } from '@angular/core';
import { RequestDetailsService } from '../shared/request/request-details.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { CreateRequestComponent } from './create-request/create-request.component';
@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styles: []
})
export class RequestComponent implements OnInit {
  public months =  ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
  public status = ['Ready','Pending','Success','Fail'];
  constructor(private service: RequestDetailsService,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.service.getRequestDetails();
  }
  openCreate() {
    this.dialog.open(CreateRequestComponent,);
  }
}
