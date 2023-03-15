import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Occurrence } from '../models/occurrence';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OccurrenceService {
  url = "Occurrence";
  constructor(public http: HttpClient) { }

  public getAll(): Observable<Occurrence[]>{
    return this.http.get<Occurrence[]>(`${environment.apiUrl}/${this.url}`);
  }
}
