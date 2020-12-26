import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {UserModel} from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserDatailsService {

  constructor(private http: HttpClient) { }

  readonly  baseURL = 'https://localhost:5001/api/User';
  public formDate: UserModel = new UserModel();

  // tslint:disable-next-line:typedef
  editUser(userProfile: UserModel) {
    return this.http.put(this.baseURL + '/UpdateUser', userProfile);
  }
  // tslint:disable-next-line:typedef
  getUserById(id: any) {
    return this.http.get(this.baseURL + '/GetUserById', {params: new HttpParams().set('id', id)});
  }
  // tslint:disable-next-line:typedef
  getAllUsers(){
    return this.http.get(this.baseURL + '/GetAllUsers');
  }
  // tslint:disable-next-line:typedef
  createUser(user: UserModel) {
    return this.http.post(this.baseURL + '/CreateUser', user);
  }
  // tslint:disable-next-line:typedef
  deleteUser(id: any){
    return this.http.delete(this.baseURL + '/DeleteUser', {params: new HttpParams().set('user', id)});
  }
  // tslint:disable-next-line:typedef
  getSortByName(){
    return this.http.get(this.baseURL + '/GetAllUsersSortByName');
  }
  // tslint:disable-next-line:typedef
  getSortByLastName(){
    return this.http.get(this.baseURL + '/GetAllUsersSortByLastName');
  }
  // tslint:disable-next-line:typedef
  getSortByGroup(){
    return this.http.get(this.baseURL + '/GetAllUsersSortByGroup');
  }

}
