import { Component, OnInit } from '@angular/core';
import {UserModel} from '../../shared/user.model';
import {UserDatailsService} from '../../shared/user-datails.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['user-edit.componennts.css'
  ]
})
export class UserEditComponent implements OnInit {


  constructor(private service: UserDatailsService) { }
  user: UserModel = new UserModel();
  ngOnInit(): void {
    this.getUserById();
  }

  // tslint:disable-next-line:typedef
  editUser(){
    this.service.editUser(this.user).subscribe();
  }

  // tslint:disable-next-line:typedef
  getUserById(){
    this.service.getUserById(sessionStorage.getItem('idCommentForEdit')).subscribe((data: any) => this.user = data);
  }
}
