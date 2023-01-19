import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-ping-event',
  templateUrl: './ping-event.component.html'
})
export class PingEventComponent {
  public pingEvents: PingEvent[] = [];
  public hostname: string = '';
  http: HttpClient;
  baseUrl: string;
  isRunning: boolean = false;
  public pingButtonText: string = 'ping';

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  delay(milliseconds: number, count: number): Promise<number> {
    return new Promise<number>(resolve => {
      setTimeout(() => {
        resolve(count);
      }, milliseconds);
    });
  }

  async onClickPingButton(): Promise<void> {
    this.pingEvents.splice(0);
    for (let i = 0; i < 5; i++) {
      this.http.get<PingEvent>(this.baseUrl + 'ping?host=' + this.hostname).subscribe(result => {
        this.pingEvents.push(result);
      }, error => console.error(error));
    }
  }
}

interface PingEvent {
  eventStart: Date;
  duration: number;
  statusCode: number;
  statusText: string;
  roundtripTime: number;
  address: string;
  ttl: number;
}
