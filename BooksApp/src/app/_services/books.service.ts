import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

const endpoint ='https://api.itbook.store/1.0/search/mondgodb/';

@Injectable({
    providedIn: 'root'
})

export class BooksService {

  constructor(private httpClient: HttpClient){}

  getAllPosts(page: number): Observable<any> {
    return this.httpClient.get(endpoint + 'page=' + page);
  }

  public getBooks(){
    return this.httpClient.get(`https://api.itbook.store/1.0/search/mongodb`);
  }

}