import { Component } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  template: ` <p>SignalR Status Connection: {{ SignalRStatus }}</p> `,
  styles: ``,
})
export class HomeComponent {
  public SignalRStatus: string = 'Not connected';
  private hubConnection!: signalR.HubConnection;

  ngOnInit(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5072/ads')
      .configureLogging(signalR.LogLevel.Information)
      .build();
    this.hubConnection.start().then(() => {
      this.SignalRStatus = 'Connected';
    });
    this.hubConnection.on('ReceiveAds', (data) => {
      alert(data);
    });
  }
}
