import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Machine } from '../_models/machine';

@Injectable()
export class MachinesService {
baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getMachines(): Observable<Machine[]> {
  return this.http.get<Machine[]>(this.baseUrl + 'machines');
}

getMachineDetails(id): Observable<Machine> {
  return this.http.get<Machine>(this.baseUrl + 'machines/machine/' + id);
}

deleteMachine(id): Observable<number> {
  return this.http.delete<number>(this.baseUrl + 'machines/machine/' + id);
}

}
