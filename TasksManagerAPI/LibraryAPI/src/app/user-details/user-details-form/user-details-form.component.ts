import { Component, OnInit } from '@angular/core';
import {UserDatailsService} from '../../shared/user-datails.service';
import {UserModel} from '../../shared/user.model';
import {Router} from '@angular/router';
import {DocumentDatailsService} from '../../shared/document-datails.service';
import {DocumentModel} from '../../shared/documentModel';

@Component({
  selector: 'app-user-details-form',
  templateUrl: './user-details-form.component.html',
  styleUrls: ['./user-details-form.component.css'
  ]
})
export class UserDetailsFormComponent implements OnInit {

  name: string | undefined ;
  user: UserModel = new UserModel();
  users: UserModel[] = [];
  document: DocumentModel = new DocumentModel();
  documents: DocumentModel[] = [];
  constructor(private service: UserDatailsService, private router: Router , private docService: DocumentDatailsService) { }

  ngOnInit(): void {
    this.loadUsers();
    this.loadDocs();
  }
  // tslint:disable-next-line:typedef
  loadUsers(){
    this.service.getAllUsers().subscribe((data: any) => this.users = data);
  }
  // tslint:disable-next-line:typedef
  deleteUser(id: any){
    this.service.deleteUser(id).subscribe(res => {
      this.ngOnInit();
    });
  }
  // tslint:disable-next-line:typedef
  editUser(id: any){
    sessionStorage.setItem('idCommentForEdit', id);
    this.router.navigateByUrl('/user/edit-user');
  }
  // tslint:disable-next-line:typedef
 sortByName(){
    this.service.getSortByName().subscribe((data: any) => this.users = data);
    this.ngOnInit();
 }
  // tslint:disable-next-line:typedef
  sortByLastName(){
    this.service.getSortByLastName().subscribe((data: any) => this.users = data);
    this.ngOnInit();
  }
  // tslint:disable-next-line:typedef
  sortByGroup(){
    this.service.getSortByGroup().subscribe((data: any) => this.users = data);
    this.ngOnInit();
  }
  // tslint:disable-next-line:typedef
  loadDocs(){
    this.docService.getAllDocuments().subscribe((data: any) => this.documents = data);
  }
  // tslint:disable-next-line:typedef
  deleteDocument(id: any){
    this.docService.deleteDocument(id).subscribe(res => {
      this.ngOnInit();
    });
}
  // tslint:disable-next-line:typedef
  editDocument(id: any){
    sessionStorage.setItem('documentEditId', id);
    this.router.navigateByUrl('/user/edit-document');
  }
  // tslint:disable-next-line:typedef
  sortDocByName(){
    this.docService.getSortByName().subscribe((data: any) => this.documents = data);
    this.ngOnInit();
  }
  // tslint:disable-next-line:typedef
  sortDocByAuthor(){
    this.docService.getSortByAuthor().subscribe((data: any) => this.documents = data);
    this.ngOnInit();
  }
  // tslint:disable-next-line:typedef
  getDocByName(){
    this.docService.getDocumentByName(this.name).subscribe((data: any) => this.documents = data);
    this.ngOnInit();
  }
  // tslint:disable-next-line:typedef
  getDocOnLibrary(){
    this.docService.getDocumentOnHandleOrInLibrary(true).subscribe((data: any) => this.documents = data);
    this.ngOnInit();
  }
  // tslint:disable-next-line:typedef
  getDocOnHandle(){
    this.docService.getDocumentOnHandleOrInLibrary(false).subscribe((data: any) => this.documents = data);
    this.ngOnInit();
  }
  // tslint:disable-next-line:typedef
  addBook(id: any){
    sessionStorage.setItem('addBookUserId', id);
    this.router.navigateByUrl('/user/add-document');
  }
}
