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
