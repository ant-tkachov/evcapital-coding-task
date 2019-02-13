import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ConfigService } from './config.service';
import { Funding } from '../models/funding.model';
import { Observable } from 'rxjs';

@Injectable()
export class FundingService {
  constructor(
    private http: HttpClient,
    private configService: ConfigService) {
  }

  fundings$():  Observable<Funding[]> {
    return this.http.get<Funding[]>(this.configService.allFundingsEndPointUrl);
  }

  invest$(fundingId: string, investorId: string, amount: number): Observable<any> {
    const data = {
       fundingId,
       investorId,
       amount
    };

    return this.http.post(this.configService.investEndPointUrl, data);
  }
}