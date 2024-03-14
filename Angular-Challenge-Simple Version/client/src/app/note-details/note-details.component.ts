import { Component } from '@angular/core';
import { Note } from '../models/note';
import { NotesService } from '../notes/notes.service';

@Component({
  selector: 'app-note-details',
  templateUrl: './note-details.component.html',
  styleUrls: ['./note-details.component.scss']
})
export class NoteDetailComponent {
  noteId: number | null = null;
  note: Note | undefined;
  showErrorToast = false;

  constructor(private notesService: NotesService) { }

  getNote(): void {
    if (this.noteId && this.noteId > 0) {
      this.notesService.getNoteById(this.noteId).subscribe({
        next: (data) => {
          this.note = data;
          this.showErrorToast = false;
        },
        error: (err) => {
          console.error(err);
          this.note = undefined; 
          this.showErrorToast = true; 
          setTimeout(() => this.showErrorToast = false, 4000); 
        }
      });
    } else {
      this.note = undefined; 
      this.showErrorToast = true; 
      setTimeout(() => this.showErrorToast = false, 4000); 
    }
  }
}