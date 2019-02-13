import { Injectable } from '@angular/core';

@Injectable()
export class ConfigService {
  private apiEndPoint: string = 'http://localhost:5000/api';

  sessionIdEndPointUrl: string;
  allFundingsEndPointUrl: string;
  investEndPointUrl: string;

  constructor() {
    this.sessionIdEndPointUrl = this.apiEndPoint + '/session/id';
    this.allFundingsEndPointUrl = this.apiEndPoint + '/funding/list';
    this.investEndPointUrl = this.apiEndPoint + '/funding/invest';
  }
}