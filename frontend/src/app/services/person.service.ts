import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models/person';
import { environment } from 'src/environments/environment';

const httpOption= {
  headers: new HttpHeaders({
    'Content-Type':'applicarion/json',
    'Accept': 'application/json' //tipo de dados que vamos enviar e receber
  })
};


@Injectable({
  providedIn: 'root'
})
export class PersonService {
  url = "Person";
  constructor(public http: HttpClient) { }

  public getAll(): Observable<Person>{
    //colocar [] dps de Person
    return this.http.get<Person>(`${environment.apiUrl}/${this.url}`);
  }

  public postPerson(person: Person): Observable<Person>{
    return this.http.post<Person>(`${environment.apiUrl}/${this.url}`, person);
  }
}
