/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MachinesService } from './machines.service';

describe('Service: Machines', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MachinesService]
    });
  });

  it('should ...', inject([MachinesService], (service: MachinesService) => {
    expect(service).toBeTruthy();
  }));
});
