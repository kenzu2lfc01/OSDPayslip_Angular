import { Injectable } from '@angular/core';
import {HttpClient}from "@angular/common/http"
import { RequestDetails } from './request-details.model';

@Injectable({
  providedIn: 'root'
})
export class RequestDetailsService {
  readonly rootUrl = 'https://localhost:44335/api';
  list: RequestDetails[];
  constructor(private http: HttpClient) { }

  getRequestDetails(){
    this.http.get(this.rootUrl + '/RequestDetail').toPromise().then(res=>this.list = res as RequestDetails[] )
  }
}
