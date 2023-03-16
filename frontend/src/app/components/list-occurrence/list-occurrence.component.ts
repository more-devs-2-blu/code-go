// Yasmin
// --------------
import { Occurrence } from './../../models/occurrence';
import { OccurrenceService } from '../../services/occurrence.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-list-occurrence',
  templateUrl: './list-occurrence.component.html',
  styleUrls: ['./list-occurrence.component.scss']
})
export class ListOccurrenceComponent implements OnInit{

  public statusSelecionado: number | null = null;
  public categorySelecionado: number | null = null;
  public districtSelecionado: number | null = null;

  public login = localStorage.getItem("UserType")

  public charactersList = new Observable<Occurrence[]>();

  public listOccurrence: Occurrence[] = [];

  constructor(public service: OccurrenceService){}

  ngOnInit(): void {

    this.charactersList = this.service.getAll();

    this.charactersList.subscribe(
      (resp) =>{
          this.listOccurrence = resp;
          console.log(this.listOccurrence);
      }
    );
  }

  GetByStatus(i: any): void {
    console.log("Get by status", i)
    this.charactersList = this.service.getByStatus(this.statusSelecionado);

    this.charactersList.subscribe(
      (resp) =>{
          this.listOccurrence = resp;
          console.log(this.listOccurrence);
      }
    );
  }

  GetByIdPerson(i: any): void {

    this.charactersList = this.service.getByIdPerson({ i });

    this.charactersList.subscribe(
      (resp) =>{
          this.listOccurrence = resp;
          console.log(this.listOccurrence);
      }
    );
  }

  GetByDistrict(i: any): void {

    this.charactersList = this.service.getByDistrict(this.districtSelecionado);

    this.charactersList.subscribe(
      (resp) =>{
          this.listOccurrence = resp;
          console.log(this.listOccurrence);
      }
    );
  }

  GetByCategory(i: any): void {

    this.charactersList = this.service.getByCategory(this.categorySelecionado);

    this.charactersList.subscribe(
      (resp) =>{
          this.listOccurrence = resp;
          console.log(this.listOccurrence);
      }
    );
  }

}




// Bernardo
// --------------
// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-list-occurrence',
//   templateUrl: './list-occurrence.component.html',
//   styleUrls: ['./list-occurrence.component.scss']
// })
// export class ListOccurrenceComponent {

// }
