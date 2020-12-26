import { Component, OnInit } from '@angular/core';
import {UserDatailsService} from '../shared/user-datails.service';
import {UserModel} from '../shared/user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styles: [
  ]
})
export class UserDetailsComponent implements OnInit {

  constructor(private service: UserDatailsService) { }

  ngOnInit(): void {
  }
  // tslint:disable-next-line:typedef


}
