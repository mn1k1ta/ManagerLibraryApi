import { Component, OnInit } from '@angular/core';
import {DocumentModel} from '../../shared/documentModel';
import {UserDatailsService} from '../../shared/user-datails.service';
import {DocumentDatailsService} from '../../shared/document-datails.service';
import {UserModel} from '../../shared/user.model';

@Component({
  selector: 'app-document-manager',
  templateUrl: './document-manager.component.html',
  styleUrls: ['add-doc.css'
  ]
})
export class DocumentManagerComponent implements OnInit {

  user: UserModel = new UserModel();
  documents: DocumentModel[] = [];
  documentsOnHandle: DocumentModel[] = [];
  constructor(private userService: UserDatailsService, private  docService: DocumentDatailsService) { }

  ngOnInit(): void {
    this.loadDocuments();
    this.loadDocumentsOnHandle();
    this.loadUser();
  }
  // tslint:disable-next-line:typedef
  loadUser(){
    this.userService.getUserById(sessionStorage.getItem('addBookUserId')).subscribe((data: any) => this.user = data);
  }
  // tslint:disable-next-line:typedef
  loadDocuments(){
    this.docService.getAllDocuments().subscribe((data: any) => this.documents = data);
  }
  // tslint:disable-next-line:typedef
  loadDocumentsOnHandle(){
    this.docService.getDocumentByUser(sessionStorage.getItem('addBookUserId')).subscribe((data: any) => this.documentsOnHandle = data);
  }
  // tslint:disable-next-line:typedef
  addBookOnUser(id: any)
  {
    this.docService.giveOutADocument(id, sessionStorage.getItem('addBookUserId')).subscribe(res => {
      this.ngOnInit();
    });
  }
  // tslint:disable-next-line:typedef
  returnDoc(id: any){
    this.docService.returnDocumetnToTheLibrary(id).subscribe(res => {
      this.ngOnInit();
    });
  }

}
