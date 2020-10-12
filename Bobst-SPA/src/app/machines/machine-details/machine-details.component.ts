import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Machine } from 'src/app/_models/machine';
import { MachineDetails } from 'src/app/_models/machineDetails';
import { MachinesService } from 'src/app/_services/machines.service';

@Component({
  selector: 'app-machine-details',
  templateUrl: './machine-details.component.html',
  styleUrls: ['./machine-details.component.css']
})
export class MachineDetailsComponent implements OnDestroy {

  machineDetails: MachineDetails;
  errorMsg = null;
  displayDetails = false;
  subscription: Subscription;
  constructor(private machineService: MachinesService) { }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  getMachineDetails(machine: Machine) {
    this.subscription = this.machineService.getMachineDetails(machine.machineId)
      .subscribe(data => {
        this.machineDetails = data;
        this.machineDetails.production = machine.production;
      }, error => this.errorMsg = error
      );
    this.displayDetails = true;
  }

  onCancel() {
    this.displayDetails = false;
  }

}
