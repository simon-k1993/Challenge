import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HttpClientModule } from '@angular/common/http';
import { NotesModule } from './notes/notes.module';
import { FormsModule } from '@angular/forms';
import { NoteDetailComponent } from './note-details/note-details.component';
import { NoteCreateComponent } from './create/create.component';
import { UpdateNoteComponent } from './update-note/update-note.component';
import { DeleteNoteComponent } from './delete-note/delete-note.component';
import { ToastComponent } from './toast/toast.component';


@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    NoteDetailComponent,
    NoteCreateComponent,
    UpdateNoteComponent,
    DeleteNoteComponent,
    ToastComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NotesModule,
    FormsModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
