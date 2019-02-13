import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ConfigService } from './config.service';

@Injectable()
export class SessionService {
  sessionId: string;

  constructor(
    private http: HttpClient,
    private configService: ConfigService) {
      this.initSessionId();
  }

  private initSessionId() {
    this.http
      .get(this.configService.sessionIdEndPointUrl, { withCredentials: true })
      .subscribe((id: string) => {
        this.sessionId = id;
      });
  }
}