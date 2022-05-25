import { HttpClient } from '@angular/common/http';

import { Injectable } from "@angular/core";
import { Customer } from "app/_models/customer";
import { ReplaySubject } from "rxjs";
import { map } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
})

export class AccountService {
  baseUrl = 'http://localhost:32679/api/';
  private currentUserSource = new ReplaySubject<Customer>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private httpClient: HttpClient){}

  register(model: any){
    return this.httpClient.post(this.baseUrl + 'Account/register', model).pipe(
      map((customer: Customer) => {
        if (customer){
          localStorage.setItem('user', JSON.stringify(customer));
          this.currentUserSource.next(customer);
        }
      })
    )
  }
  

}