import { Component, OnInit } from '@angular/core';
import { PayslipDetailsService } from '../../shared/payslip/payslip-details.service';

@Component({
  selector: 'app-payslip-details',
  templateUrl: './payslip-details.component.html',
  styles: []
})
export class PayslipDetailsComponent implements OnInit {

  constructor(private service: PayslipDetailsService) { }
  ngOnInit() {
  }

}
