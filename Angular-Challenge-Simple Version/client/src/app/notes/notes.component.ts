import { Component, OnInit } from '@angular/core';
import { Note } from '../models/note';
import { NotesService } from './notes.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit{
  notes: Note[] = [];

  constructor(private noteService: NotesService) {}

  ngOnInit(): void {
    this.noteService.getNotes().subscribe({
      next: response => this.notes = response,
      error: error => console.log(error)
    })
  }

}
