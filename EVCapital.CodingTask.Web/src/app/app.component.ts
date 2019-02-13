import { Component } from '@angular/core';

import { FundingService } from './services/funding.service';
import { Funding } from './models/funding.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  fundings: Funding[] = [];

  constructor(
    private fundingService: FundingService
  ) {
    this.initFundings();
  }

  private initFundings() {
    this.fundingService.fundings$().subscribe((fundings: Funding[]) => {
      this.fundings = fundings;
    });
  }
}

