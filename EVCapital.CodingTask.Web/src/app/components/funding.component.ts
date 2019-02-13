import { Component, Input } from '@angular/core';
import { Funding } from '../models/funding.model';
import { FundingService } from '../services/funding.service';
import { SessionService } from '../services/session.service';

@Component({
  selector: 'funding',
  templateUrl: './funding.component.html',
  styleUrls: ['./funding.component.css']
})
export class FundingComponent {
  @Input() value: Funding;
  @Input() amount?: number;

  constructor(
      private sessionService: SessionService,
      private fundingService: FundingService) {
  }

  invest() {
    const sessionId = this.sessionService.sessionId;
    this.fundingService
        .invest$(this.value.id, sessionId, this.amount)
        .subscribe(() => {
            this.amount = null;
            this.value.investorIds.push(sessionId);
        });;
  }

  hasInvested() {
    const sessionId = this.sessionService.sessionId;
    return this.value.investorIds.indexOf(sessionId) > -1;
  }
}
