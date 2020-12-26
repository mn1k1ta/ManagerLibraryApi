import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {UserModel} from './user.model';
import {DocumentModel} from './documentModel';

@Injectable({
  providedIn: 'root'
})
export class DocumentDatailsService {

  constructor(private http: HttpClient) { }

  readonly  baseURL = 'https://localhost:5001/api/Document';
  public formDate: DocumentModel = new DocumentModel();

  // tslint:disable-next-line:typedef
  editDocument(userProfile: DocumentModel) {
    return this.http.put(this.baseURL + '/UpdateDocument', userProfile);
  }
  // tslint:disable-next-line:typedef
  getDocumentById(id: any) {
    return this.http.get(this.baseURL + '/GetDocumentById', {params: new HttpParams().set('id', id)});
  }
  // tslint:disable-next-line:typedef
  getAllDocuments(){
    return this.http.get(this.baseURL + '/GetAllDocuments');
  }
  // tslint:disable-next-line:typedef
  createDocument(document: DocumentModel) {
    return this.http.post(this.baseURL + '/CreateDocument', document);
  }
  // tslint:disable-next-line:typedef
  deleteDocument(id: any){
    return this.http.delete(this.baseURL + '/DeleteDocument', {params: new HttpParams().set('document', id)});
  }
  // tslint:disable-next-line:typedef
  getSortByName(){
    return this.http.get(this.baseURL + '/GetAllDocumentsSortByName');
  }
  // tslint:disable-next-line:typedef
  getSortByAuthor(){
    return this.http.get(this.baseURL + '/GetAllDocumentsSortByAuthor');
  }
  // tslint:disable-next-line:typedef
  getDocumentByUser(id: any){
    return this.http.get(this.baseURL + '/GetDocumentByUser', { params: new HttpParams().set('id', id)});
  }
  // tslint:disable-next-line:typedef
  getDocumentByName(name: any){
    return this.http.get(this.baseURL + '/GetDocumentByName', { params: new HttpParams().set('name', name)});
  }
  // tslint:disable-next-line:typedef
  getDocumentOnHandleOrInLibrary(type: any){
    return this.http.get(this.baseURL + '/GetDocumentOnHandleOrInLibrary', { params: new HttpParams().set('type', type)});
  }
  // tslint:disable-next-line:typedef
  returnDocumetnToTheLibrary(document: any) {
    return this.http.get(this.baseURL + '/ReturnDocumetnToTheLibrary', { params: new HttpParams().set('documentId', document)});
  }
  // tslint:disable-next-line:typedef
  giveOutADocument(documentId: any, userId: any) {
    // tslint:disable-next-line:max-line-length
    return this.http.get(this.baseURL + '/GiveOutADocument', { params: new HttpParams().set('documentId', documentId).set('userId', userId)});
  }
}
