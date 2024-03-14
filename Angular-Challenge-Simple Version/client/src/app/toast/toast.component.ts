import { ChangeDetectorRef, Component } from '@angular/core';
import { ToastService } from '../toast.service';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.scss']
})
export class ToastComponent {
  constructor(public toastService: ToastService, private cdr: ChangeDetectorRef) {}

  checkForChanges(): void {
    this.cdr.detectChanges();
  }
}
