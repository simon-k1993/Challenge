import { ChangeDetectorRef, Component } from '@angular/core';
import { NotesService } from '../notes/notes.service';
import { NoteAddDTO } from '../models/noteAdd';
import { Status } from '../models/noteStatus';
import { NgForm } from '@angular/forms';



@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})


export class NoteCreateComponent {
  newNote: NoteAddDTO = this.getInitialNoteState();
  statusEnum = Status;
  showToast = false;
  toastType: 'success' | 'error' = 'error';
  errorMessage: string = '';

  constructor(private noteService: NotesService, private cdr: ChangeDetectorRef) {}

  addNote(noteForm: NgForm): void {
    if (noteForm.valid) {
        this.noteService.addNote(this.newNote).subscribe({
            next: (response) => {
                this.errorMessage = 'Note added successfully';
                this.toastType = 'success';
                this.showToast = true;
                setTimeout(() => {
                    this.showToast = false;
                }, 4000);
                this.resetForm(noteForm);
            },
            error: (error) => {
                console.error('There was an error adding the note:', error);
                this.errorMessage = 'Error adding note. Please try again.';
                this.toastType = 'error';
                this.showToast = true;
                setTimeout(() => {
                    this.showToast = false;
                }, 4000);
            }
        });
    } else {
        this.errorMessage = 'All fields are required';
        this.toastType = 'error';
        this.showToast = true;
        setTimeout(() => {
            this.showToast = false;
        }, 4000);
    }
}

  private resetForm(noteForm: NgForm): void {
    this.newNote = this.getInitialNoteState();
    noteForm.resetForm();
  }

  private getInitialNoteState(): NoteAddDTO {
    return { name: '', dueDate: new Date(), description: '', status: Status.Incomplete };
  }
}