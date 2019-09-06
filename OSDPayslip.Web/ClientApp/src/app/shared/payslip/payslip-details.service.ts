import { Injectable } from '@angular/core';
import { OutputEmployeePayslipList, PayslipDetails } from './payslip-details.model';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class PayslipDetailsService {
  readonly rootUrl = 'https://localhost:44335/api';
  employeePayslipsList: OutputEmployeePayslipList[];
  payslipList: PayslipDetails[];
  constructor(private http: HttpClient) { }
  getEmployeePayslipsList(id) {
    this.http.get(this.rootUrl + `/PayslipDetail/${id.Id}`).toPromise().then(res => this.employeePayslipsList = res as OutputEmployeePayslipList[])
  }
  getPayslipsList(id){
    this.http.get(this.rootUrl + `/PayslipDetail/getpayslips/${id.Id}`).toPromise().then(res => this.payslipList = res as PayslipDetails[])
  }
}
