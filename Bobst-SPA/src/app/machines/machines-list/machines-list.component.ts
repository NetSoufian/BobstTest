import { Component, OnInit } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { Machine } from 'src/app/_models/machine';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MachinesService } from 'src/app/_services/machines.service';

@Component({
  selector: 'app-machines-list',
  templateUrl: './machines-list.component.html',
  styleUrls: ['./machines-list.component.css']
})
export class MachinesListComponent implements OnInit {

  machines: Machine[] = [];
  machine: Machine = null;
  errorMsg = null;
  subscriptionMachineDetailes: Subscription;
  displayDetails: boolean;
  totaleProduction: number;

  constructor(private machinesService: MachinesService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.getMachines();
  }

  getMachines() {
    this.machinesService.getMachines()
      .subscribe(data => this.machines = data,
        error => this.errorMsg = error);
  }

  getMachine(id) {
    this.getMachineDetails(id);
    this.subscriptionMachineDetailes = interval(5000).subscribe(
      () => {
        this.getMachineDetails(id);
        this.alertify.success("Refreshed")
      });
  }

  getMachineDetails(id) {
    this.displayDetails = true;
    this.machinesService.getMachineDetails(id)
      .subscribe(data => {
        this.machine = data;
        this.machinesService.getTotalProduction(id).subscribe(
          p => { this.machine.totalProduction = p.totalProduction;
          }, error => this.errorMsg = error
        );
      }, error => this.errorMsg = error
      );
  }

  onDelete(id) {
    this.machinesService.deleteMachine(id)
      .subscribe(data => {
        const isDeleted = data;
        if (isDeleted === 1) {
          this.getMachines();
          this.alertify.success('machine deleted succefully.');
        }
      },
        error => this.errorMsg = error);
  }

  hideMachinesList(eventData: boolean) {
    this.displayDetails = eventData;
    this.subscriptionMachineDetailes.unsubscribe();
  }
}
