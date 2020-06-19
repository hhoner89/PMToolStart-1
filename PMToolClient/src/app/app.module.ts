import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestComponent } from './pages/test/test.component';
import { PlanComponent } from './pages/plan/plan.component';
import { FormsModule }   from '@angular/forms';
import { PlanListComponent } from './pages/plan-list/plan-list.component';

import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    PlanComponent,
    PlanListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
