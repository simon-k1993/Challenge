import { Component, OnInit } from '@angular/core';
import { NotesService } from '../notes/notes.service';
import { Status } from '../models/noteStatus';
import { NoteUpdate } from '../models/noteUpdate';
import { Note } from '../models/note';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-note',
  templateUrl: './update-note.component.html',
  styleUrls: ['./update-note.component.scss']
})

export class UpdateNoteComponent implements OnInit {
  noteId: number | null = null;
  note: NoteUpdate = { name: '', dueDate: '', description: '', status: Status.Incomplete };
  statusEnum = Status;
  showErrorToast = false;
  toastMessage = '';
  toastType: 'success' | 'error' = 'error';

  constructor(private notesService: NotesService,private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.noteId = +id;
        this.fetchNote();
      }
    });
  }

  fetchNote(): void {
    if (this.noteId && this.noteId > 0) {
        this.notesService.getNoteById(this.noteId).subscribe({
            next: (note: Note) => {
                this.note = {
                    name: note.name,
                    dueDate: note.dueDate,
                    description: note.description,
                    status: this.convertStatusFromString(note.status)
                };
                this.showErrorToast = false;
            },
            error: (err) => {
                console.error('Failed to fetch note:', err);
                this.showErrorToast = true;
                this.toastMessage = 'Failed to fetch note. Please check the ID.';
                this.toastType = 'error';
            }
        });
    } else {
        console.error('Valid Note ID is required to fetch a note.');
        this.showErrorToast = true;
        this.toastMessage = 'Valid Note ID is required to fetch a note.';
        this.toastType = 'error';
    }
}


  updateNote(): void {

    if (this.noteId && this.noteId > 0 && this.note.name && this.note.description) {
        this.notesService.updateNote(this.noteId, this.note).subscribe({
            next: () => {
                this.showErrorToast = true;
                this.toastMessage = `Note with ID ${this.noteId} updated successfully.`;
                this.toastType = 'success';
                setTimeout(() => {
                    this.showErrorToast = false;
                }, 4000);
            },
            error: (err) => {
                console.error('Update failed:', err);
                this.showErrorToast = true;
                this.toastMessage = `Update failed: Note with ID ${this.noteId} does not exist.`;
                this.toastType = 'error';
                setTimeout(() => {
                    this.showErrorToast = false;
                }, 4000);
            }
        });
    } else {
        console.error('Name and Description are required');
        this.showErrorToast = true;
        this.toastMessage = 'Name and Description are required';
        this.toastType = 'error';
        setTimeout(() => {
            this.showErrorToast = false;
        }, 4000);
    }
}

  convertStatusFromString(statusString: string): Status {
    switch (statusString) {
        case 'Complete':
            return Status.Complete;
        case 'Incomplete':
            return Status.Incomplete;
        default:
            throw new Error(`Unknown status string: ${statusString}`);
    }
}

  private resetForm(): void {
    this.note = { name: '', dueDate: '', description: '', status: Status.Incomplete };
    this.noteId = null;
  }
}