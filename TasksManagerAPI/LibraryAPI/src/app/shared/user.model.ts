export class UserModel {
  userId: number;
  firstName: string;
  lastName: string;
  group: string;

  constructor() {
    this.userId = 0;
    this.firstName = '';
    this.lastName = '';
    this.group = '';
  }
}
