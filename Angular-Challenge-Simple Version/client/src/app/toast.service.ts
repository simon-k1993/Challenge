import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  toasts: any[] = [];

  show(message: string, duration: number = 3000): void {
    console.log(`Showing toast: ${message}`);
    const toast = { message, duration };
    this.toasts.push(toast);
    setTimeout(() => this.remove(toast), duration);
  }

  remove(toast: any): void {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}