import { ToastrModule } from 'ngx-toastr';
import { BooksService } from '../_services/books.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  books: any;
  page: number = 1;
  total: number = 0; 
  tableSize: number = 7;
  tableSizes: any = [3, 6, 9, 12];

  constructor(private booksService:BooksService) { }
  
  ngOnInit() {
    this.fetchPosts();

   this.booksService.getBooks().subscribe ((data)=>{
     console.log(data);
     this.books = data['books'];
   });  
  }
  fetchPosts(): void {
    this.booksService.getAllPosts(this.page).subscribe(
      (response) => {
        this.books = response;
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
  onTableDataChange(event: any) {
    this.page = event;
    this.fetchPosts();
  }
  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchPosts();
  }
}
