import { Component, OnInit } from '@angular/core';
import { PayslipDetailsService } from '../shared/payslip/payslip-details.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from "@angular/common/http"
@Component({
  selector: 'app-paylips',
  templateUrl: './paylips.component.html',
  styles: ['./paylips.component.css']
})
export class PaylipsComponent implements OnInit {

  constructor(private service: PayslipDetailsService, private activatedRoute: ActivatedRoute,private http: HttpClient) { }
  public displayedColumns = ['stt', 'employeeId', 'employeeName', 'email', 'status', 'action'];
  public status = ['Ready', 'Pending', 'Success', 'Fail'];

  Id: any;
  ngOnInit() {
    this.activatedRoute.params.subscribe(Id => {
      this.Id = Id;
    });
    this.service.getEmployeePayslipsList(this.Id);
    this.service.getPayslipsList(this.Id);
  }
  SendMail(){
    const formData = new FormData();
    formData.append("RequestId",this.Id.Id.toString());
    const uploadReq = this.service.sendMail(formData);
    this.http.request(uploadReq);
  }
}
