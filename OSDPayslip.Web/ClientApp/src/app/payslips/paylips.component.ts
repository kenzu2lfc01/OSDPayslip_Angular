import { Component, OnInit } from '@angular/core';
import { PayslipDetailsService } from '../shared/payslip/payslip-details.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-paylips',
  templateUrl: './paylips.component.html',
  styles: ['./paylips.component.css']
})
export class PaylipsComponent implements OnInit {

  constructor(private service: PayslipDetailsService, private activatedRoute: ActivatedRoute) { }
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

}
