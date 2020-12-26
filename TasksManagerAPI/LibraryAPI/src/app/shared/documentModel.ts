export class DocumentModel {
  documetnId: number;
  name: string;
  description: string;
  author: string;
  genre: string;
  documentStatus: any;

  constructor() {
    this.documetnId = 0;
    this.name = '';
    this.description = '';
    this.author = '';
    this.genre = '';
  }
}
