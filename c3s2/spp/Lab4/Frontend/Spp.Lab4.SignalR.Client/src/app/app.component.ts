import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import {
  HubConnection,
  HubConnectionBuilder,
  LogLevel,
} from '@microsoft/signalr';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  styleUrl: './app.component.css',
  template: ` <section>
    <div>
      <router-outlet></router-outlet>
    </div>
  </section>`,
})
export class AppComponent {
  title = 'Spp.Lab4.SignalR.Client';
}
