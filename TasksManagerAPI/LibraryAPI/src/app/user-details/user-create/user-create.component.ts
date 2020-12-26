import { Component, OnInit } from '@angular/core';
import {UserModel} from '../../shared/user.model';
import {UserDatailsService} from '../../shared/user-datails.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['user-create.component.css'
  ]
})
export class UserCreateComponent implements OnInit {

  user: UserModel = new UserModel();
  constructor(private service: UserDatailsService, private router: Router) { }

  ngOnInit(): void {

  }
  // tslint:disable-next-line:typedef
  createUser(model: UserModel){
    this.service.createUser(model).subscribe(res => {
      this.ngOnInit();
    });
  }
}
