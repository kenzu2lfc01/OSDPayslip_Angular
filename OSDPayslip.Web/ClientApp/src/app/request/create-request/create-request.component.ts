import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { RequestDetailsService } from 'src/app/shared/request/request-details.service';
import { CreateRequestInput } from 'src/app/shared/request/request-details.model';
@Component({
  selector: 'app-create-request',
  templateUrl: './create-request.component.html',
  styles: []
})
export class CreateRequestComponent implements OnInit {

  public payslipForMonth = [
    { month: "January", selector: 1 },
    { month: "February", selector: 2 },
    { month: "March", selector: 3 },
    { month: "April", selector: 4 },
    { month: "May", selector: 5 },
    { month: "June", selector: 6 },
    { month: "July", selector: 7 },
    { month: "August", selector: 8 },
    { month: "September", selector: 9 },
    { month: "October", selector: 10 },
    { month: "November", selector: 11 },
    { month: "December", selector: 12 },
  ]
 
  public filename = "Choose Excel File";
  public selectedValue = 1;
  fileValue: any;
  
  constructor(private dialogRef: MatDialogRef<CreateRequestComponent>, private service: RequestDetailsService) { }
  createRequest() {
  }
  

  ngOnInit() {
  }
  upload(value) {
    this.filename = value[0].name;
    this.fileValue = value[0];
  }
  closeDispay() {
    this.dialogRef.close();
  }
  onChange(event) {
    this.selectedValue = event.target.value;
  }
}
