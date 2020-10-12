import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { interval } from 'rxjs';
import { Machine } from 'src/app/_models/machine';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { MachinesService } from 'src/app/_services/machines.service';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy({ checkProperties: true })
@Component({
  selector: 'app-machines-list',
  templateUrl: './machines-list.component.html',
  styleUrls: ['./machines-list.component.css']
})
export class MachinesListComponent implements OnInit {

  @Output() notify: EventEmitter<Machine> = new EventEmitter<Machine>();
  machines: Machine[];
  errorMsg = null;

  constructor(private machinesService: MachinesService, private alertify: AlertifyService) { }

  ngOnInit() {
    interval(5000).subscribe(
      () => {
        this.getMachines();
        console.log('GO');
      });
  }

  getMachines() {
    this.machinesService.getMachines()
      .subscribe(data => this.machines = data,
        error => this.errorMsg = error);
  }

  handleClick(id) {
    console.log(this.machines.find(m => m.machineId === id));
    this.notify.emit(this.machines.find(m => m.machineId === id));
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


}
