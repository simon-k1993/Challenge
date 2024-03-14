import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotesComponent } from './notes/notes.component';
import { NoteDetailComponent } from './note-details/note-details.component';
import { NoteCreateComponent } from './create/create.component';
import { UpdateNoteComponent } from './update-note/update-note.component';
import { DeleteNoteComponent } from './delete-note/delete-note.component';

const routes: Routes = [
  { path: 'notes', component: NotesComponent },
  { path: 'note-detail', component: NoteDetailComponent },
  { path: 'create-note', component: NoteCreateComponent },
  { path: 'update-note', component: UpdateNoteComponent },
  { path: 'delete-note', component: DeleteNoteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
