import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FundingComponent } from './funding.component';
import { SessionService } from '../services/session.service';
import { FundingService } from '../services/funding.service';

describe('FundingComponent', () => {
  let fixture: ComponentFixture<FundingComponent>;
  let component: FundingComponent;

  beforeEach(() => {
    const sessionServiceStub = {};
    const fundingServiceStub = {};

    TestBed.configureTestingModule({
        declarations: [
            FundingComponent
        ],
        imports: [
          BrowserAnimationsModule,
          RouterTestingModule
        ],
        providers: [
          { provide: SessionService, useValue: sessionServiceStub },
          { provide: FundingService, useValue: fundingServiceStub }
        ]
    });

    fixture = TestBed.createComponent(FundingComponent);
    fixture.detectChanges();
    component = fixture.nativeElement;
  });

  afterEach(() => {
    fixture.destroy();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
