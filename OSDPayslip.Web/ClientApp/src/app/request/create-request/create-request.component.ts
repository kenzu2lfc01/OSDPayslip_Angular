import { Component, OnInit, HostListener } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { RequestDetailsService } from 'src/app/shared/request/request-details.service';

import { HttpClient, HttpEventType } from "@angular/common/http"

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
  public progress: number;
  public message: string;
  constructor(private dialogRef: MatDialogRef<CreateRequestComponent>, private service: RequestDetailsService, private http: HttpClient) {
    dialogRef.disableClose = true;
    dialogRef.backdropClick().subscribe(() => {
      dialogRef.close();
    })
  }
  createRequest() {
    const formData = new FormData();
    for (let file of this.fileValue) {
      formData.append(file.filename, file);
      formData.append("Month", this.selectedValue.toString());
    }

    const uploadReq = this.service.createNewRequest(formData);
    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress)
        this.progress = Math.round(100 * event.loaded / event.total);
      else if (event.type === HttpEventType.Response)
        this.message = event.body.toString();
    });
    this.service.getRequestDetails();
  }
  
  @HostListener('window:keyup.esc') onKeyUp() {
    this.dialogRef.close();
  }


  ngOnInit() {
  }
  upload(value) {
    this.filename = value[0].name;
    this.fileValue = value;
  }
  closeDispay() {
    this.dialogRef.close();
  }
  onChange(event) {
    this.selectedValue = event.target.value;
  }
}
