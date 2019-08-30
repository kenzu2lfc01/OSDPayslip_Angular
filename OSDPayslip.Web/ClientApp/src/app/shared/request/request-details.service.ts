import { Injectable } from '@angular/core';
import {HttpClient}from "@angular/common/http"
import { RequestDetails,CreateRequestInput } from './request-details.model';

@Injectable({
  providedIn: 'root'
})
export class RequestDetailsService {
  readonly rootUrl = 'https://localhost:44335/api';
  list: RequestDetails[];
  temp: CreateRequestInput
  constructor(private http: HttpClient) { }
  getRequestDetails(){
    this.http.get(this.rootUrl + '/RequestDetail').toPromise().then(res=>this.list = res as RequestDetails[] )
  }
  createNewRequest(data:CreateRequestInput)
  {
    this.temp.PayslipForMonth = data.PayslipForMonth;
    this.temp.File= data.File;
    debugger;
    this.http.post(this.rootUrl + "/RequestDetail/newrequest",this.temp)
  }
}