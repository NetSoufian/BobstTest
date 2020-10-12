import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MachinesService } from './_services/machines.service';
import { MachinesListComponent } from './machines/machines-list/machines-list.component';
import { MachineDetailsComponent } from './machines/machine-details/machine-details.component';
import { AlertifyService } from './_services/alertify.service';

@NgModule({
  declarations: [
    AppComponent,
    MachinesListComponent,
    MachineDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    MachinesService,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
