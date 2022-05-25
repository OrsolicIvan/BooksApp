import { Injectable } from '@angular/core';
import { Author } from '../shared/author.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'http://localhost:32679/api/Author'
  formData:Author = new Author();
  list: Author[];

  postAuthor(){
   return this.http.post(this.baseURL,this.formData);
  }
  putAuthor(){
    return this.http.put(`${this.baseURL}/${this.formData.authorId}`,this.formData);
  }

  deleteAuthor(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshlist(){
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => this.list = res as Author[]);
  }
  
}
