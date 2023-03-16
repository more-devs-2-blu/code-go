import { Occurrence } from './../../models/occurrence';
import { OccurrenceService } from '../../services/occurrence.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-occurrence',
  templateUrl: './list-occurrence.component.html',
  styleUrls: ['./list-occurrence.component.scss']
})
export class ListOccurrenceComponent implements OnInit {

  public occurrenceSelected: Occurrence | undefined;

  public statusSelecionado: number | null = null;
  public categorySelecionado: number | null = null;
  public districtSelecionado: number | null = null;

  public login = localStorage.getItem("UserType")

  public occurrencesList$: Observable<Occurrence[]> | undefined;

  public listOccurrence: Occurrence[] = [];

  constructor(public service: OccurrenceService, private router: Router) { }

  ngOnInit(): void {
    this.occurrencesList$ = this.service.getAll();

    this.occurrencesList$.subscribe(
      (resp) => {
        this.listOccurrence = resp;
        console.log(this.listOccurrence);
      }
    );
  }

  GetByStatus(i: any): void {
    console.log("Get by status", i)
    this.occurrencesList$ = this.service.getByStatus(this.statusSelecionado);

    this.occurrencesList$.subscribe(
      (resp) => {
        this.listOccurrence = resp;
        console.log(this.listOccurrence);
      }
    );
  }
 
  GetByIdPerson(i: any): void {
    this.occurrencesList$ = this.service.getByIdPerson({ i });

    this.occurrencesList$.subscribe(
      (resp) => {
        this.listOccurrence = resp;
        console.log(this.listOccurrence);
      }
    );
  }

  GetByDistrict(i: any): void {
    this.occurrencesList$ = this.service.getByDistrict(this.districtSelecionado);

    this.occurrencesList$.subscribe(
      (resp) => {
        this.listOccurrence = resp;
        console.log(this.listOccurrence);
      }
    );
  }

  GetByCategory(i: any): void {
    this.occurrencesList$ = this.service.getByCategory(this.categorySelecionado);

    this.occurrencesList$.subscribe(
      (resp) => {
        this.listOccurrence = resp;
        console.log(this.listOccurrence);
      }
    );
  }

  selectOccurrence(occurrence: any) {
    this.occurrenceSelected = occurrence;
  }
  
}
