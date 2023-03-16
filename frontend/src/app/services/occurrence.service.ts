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

  public getByStatus(i: any): Observable<Occurrence[]>{
    return this.http.get<Occurrence[]>(`${environment.apiUrl}/${this.url}/Status/${i}`);
  }

  public getByIdPerson(i: any): Observable<Occurrence[]>{
    return this.http.get<Occurrence[]>(`${environment.apiUrl}/${this.url}/idPerson/${i}`);
  }

  public getByDistrict(i: any): Observable<Occurrence[]>{
    return this.http.get<Occurrence[]>(`${environment.apiUrl}/${this.url}/District/${i}`);
  }

  public getByCategory(i: any): Observable<Occurrence[]>{
    return this.http.get<Occurrence[]>(`${environment.apiUrl}/${this.url}/Category/${i}`);
  }
}
