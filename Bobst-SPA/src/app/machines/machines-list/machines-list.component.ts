import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { Machine } from 'src/app/_models/machine';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MachinesService } from 'src/app/_services/machines.service';

@Component({
  selector: 'app-machines-list',
  templateUrl: './machines-list.component.html',
  styleUrls: ['./machines-list.component.css']
})
export class MachinesListComponent implements OnInit, OnDestroy {

  @Output() notify: EventEmitter<Machine> = new EventEmitter<Machine>();
  machines: Machine[];
  errorMsg = null;
  subscriptions: Subscription[] = [];

  constructor(private machinesService: MachinesService, private alertify: AlertifyService) { }

  ngOnInit() {
    const subscriptionMachines = interval(5000).subscribe(
      () => {
        this.getMachines();
      });

    // this.subscriptions.push(subscriptionMachines);
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sbs => sbs.unsubscribe());
  }

  getMachines() {
    this.machinesService.getMachines()
      .subscribe(data => this.machines = data,
        error => this.errorMsg = error);
  }

  handleClick(id) {
    this.notify.emit(this.machines.find(m => m.machineId === id));
  }

  onDelete(id) {
    const subscriptionDelete = this.machinesService.deleteMachine(id)
      .subscribe(data => {
        const isDeleted = data;
        if (isDeleted === 1) {
          this.getMachines();
          this.subscriptions.push(subscriptionDelete);
          this.alertify.success('machine deleted succefully.');
        }
      },
        error => this.errorMsg = error);
  }


}
