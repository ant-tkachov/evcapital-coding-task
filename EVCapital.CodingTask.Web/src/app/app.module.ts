import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { FundingComponent } from './components/funding.component';

import { SessionService } from './services/session.service';
import { ConfigService } from './services/config.service';
import { FundingService } from './services/funding.service';

@NgModule({
  declarations: [
    AppComponent,
    FundingComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule
  ],
  providers: [
    ConfigService,
    SessionService,
    FundingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
