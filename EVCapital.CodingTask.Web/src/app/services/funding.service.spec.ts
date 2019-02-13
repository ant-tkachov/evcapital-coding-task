import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { FundingService } from './funding.service';
import { ConfigService } from './config.service';

describe('FundingService', () => {
  beforeEach(() => {
    const configServiceStub = {};

    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        FundingService,
        { provide: ConfigService, useValue: configServiceStub }
      ]
    });
  });

  it('should be created', inject([FundingService], (service: FundingService) => {
    expect(service).toBeTruthy();
  }));
});
