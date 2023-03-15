import { Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models/person';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  url = "Person";
  constructor(public http: HttpClient) { }

  public getAll(): Observable<Person>{
    return this.http.get<Person>(`${environment.apiUrl}/${this.url}`);
  }
}
