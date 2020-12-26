import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserDetailsFormComponent } from './user-details/user-details-form/user-details-form.component';
import { UserDetailsComponent } from './user-details/user-details.component';
import { HttpClientModule} from '@angular/common/http';
import { UserCreateComponent } from './user-details/user-create/user-create.component';
import { UserEditComponent } from './user-details/user-edit/user-edit.component';
import { DocumentCreateComponent } from './user-details/document-create/document-create.component';
import { DocumentEditComponent } from './user-details/document-edit/document-edit.component';
import { DocumentManagerComponent } from './user-details/document-manager/document-manager.component';

@NgModule({
  declarations: [
    AppComponent,
    UserDetailsFormComponent,
    UserDetailsComponent,
    UserCreateComponent,
    UserEditComponent,
    DocumentCreateComponent,
    DocumentEditComponent,
    DocumentManagerComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    CommonModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

