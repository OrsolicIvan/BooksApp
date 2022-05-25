import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Author } from 'app/shared/author.model';
import { AuthorService } from 'app/_services/author.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-typography',
  templateUrl: './typography.component.html',
  styleUrls: ['./typography.component.css']
})
export class TypographyComponent implements OnInit {

  constructor(public service:AuthorService, private toastr:ToastrService) { }

  ngOnInit() {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.authorId==0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form:NgForm){
    this.service.postAuthor().subscribe(
      res =>{
        this.resetForm(form);
        this.service.refreshlist();
        this.toastr.success('Submitted successfully')
      },
      err =>{console.log(err);}
    );

    }

    updateRecord(form:NgForm){
      this.service.putAuthor().subscribe(
        res =>{
          this.resetForm(form);
          this.service.refreshlist();
          //this.toastr.info('Updated successfully')
        },
        err =>{console.log(err);}
      );
}

    resetForm(form:NgForm){
      form.form.reset();
      this.service.formData = new Author();
  }

}
