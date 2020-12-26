import { Component, OnInit } from '@angular/core';
import {DocumentModel} from '../../shared/documentModel';
import {DocumentDatailsService} from '../../shared/document-datails.service';

@Component({
  selector: 'app-document-edit',
  templateUrl: './document-edit.component.html',
  styleUrls: ['document-edit-details.css'
  ]
})
export class DocumentEditComponent implements OnInit {

  document: DocumentModel = new DocumentModel();
  constructor(private service: DocumentDatailsService) { }

  ngOnInit(): void {
    this.service.getDocumentById(sessionStorage.getItem('documentEditId')).subscribe((data: any) => this.document = data);
  }
  // tslint:disable-next-line:typedef
  editDocument(){
    this.service.editDocument(this.document).subscribe();
  }
}
