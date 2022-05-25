import { Component, OnInit } from '@angular/core';
import { Author } from 'app/shared/author.model';
import { AuthorService } from 'app/_services/author.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrls: ['./table-list.component.css']
})
export class TableListComponent implements OnInit {

  constructor(public service: AuthorService, private toastr:ToastrService) { }

  ngOnInit() {

    this.service.refreshlist();

  }

  populateForm(selectedRecord:Author){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure to delete this record?'))
  {
    this.service.deleteAuthor(id)
    .subscribe(
      res => {
        this.service.refreshlist();
        this.toastr.error("Deleted successfully", 'Author register')
      },
      err => {console.log(err)},
    )
  }
}
}
