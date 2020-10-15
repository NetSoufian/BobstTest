import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Machine } from 'src/app/_models/machine';

@Component({
  selector: 'app-machine-details',
  templateUrl: './machine-details.component.html',
  styleUrls: ['./machine-details.component.css']
})
export class MachineDetailsComponent {

  @Input() machineDetails: Machine;
  @Output() notify: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() { }

  onCancel() {
    this.notify.emit(false) ;
  }
}
