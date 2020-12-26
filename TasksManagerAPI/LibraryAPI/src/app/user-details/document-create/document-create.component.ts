import { Component, OnInit } from '@angular/core';
import {DocumentModel} from '../../shared/documentModel';
import {DocumentDatailsService} from '../../shared/document-datails.service';

@Component({
  selector: 'app-document-create',
  templateUrl: './document-create.component.html',
  styleUrls: ['document-details-create.css'
  ]
})
export class DocumentCreateComponent implements OnInit {

  document: DocumentModel = new DocumentModel();
  constructor(private service: DocumentDatailsService) { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line:typedef
  createDocument(document: DocumentModel){
    this.service.createDocument(document).subscribe();
  }
}
