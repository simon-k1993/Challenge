import { Status } from "./noteStatus";

export interface NoteAddDTO {
  name: string;
  dueDate: Date;
  description: string;
  status: Status;
}