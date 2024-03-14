import { Component } from '@angular/core';
import { NotesService } from '../notes/notes.service';

@Component({
  selector: 'app-delete-note',
  templateUrl: './delete-note.component.html',
  styleUrls: ['./delete-note.component.scss']
})
export class DeleteNoteComponent {
  id: number | null = null;
  showErrorToast = false;
  errorMessage: string = '';
  toastType: 'success' | 'error' = 'error';

  constructor(private noteService: NotesService) {}

  deleteNote(): void {
    if (this.id && typeof this.id === 'number') {
      this.noteService.deleteNote(this.id).subscribe({
        next: (res) => {
          this.showErrorToast = true;
          this.toastType = 'success';
          this.errorMessage = `Note with ID ${this.id} is deleted successfully`;
          this.id = null;
          setTimeout(() => this.showErrorToast = false, 4000);
        },
        error: (e) => {
          this.showErrorToast = true;
          this.toastType = 'error';
          this.errorMessage = `Note with ID ${this.id} does not exist`;
          setTimeout(() => this.showErrorToast = false, 4000);
        }
      });
    } else {
      this.showErrorToast = true;
      this.toastType = 'error';
      this.errorMessage = 'Invalid note ID';
      setTimeout(() => this.showErrorToast = false, 4000);
    }
  }
}