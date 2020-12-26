import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserDetailsFormComponent } from './user-details/user-details-form/user-details-form.component';
import {UserDetailsComponent} from './user-details/user-details.component';
import {UserCreateComponent} from './user-details/user-create/user-create.component';
import {UserEditComponent} from './user-details/user-edit/user-edit.component';
import {DocumentCreateComponent} from './user-details/document-create/document-create.component';
import {DocumentEditComponent} from './user-details/document-edit/document-edit.component';
import {DocumentManagerComponent} from './user-details/document-manager/document-manager.component';

const routes: Routes = [
  {path: 'user' , component : UserDetailsComponent,
  children: [
    {path: 'gets' , component : UserDetailsFormComponent},
    {path: 'create-user' , component : UserCreateComponent},
    {path: 'edit-user' , component : UserEditComponent},
    {path: 'create-document' , component : DocumentCreateComponent},
    {path: 'edit-document' , component : DocumentEditComponent},
    {path: 'add-document' , component : DocumentManagerComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
