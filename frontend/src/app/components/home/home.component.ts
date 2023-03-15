import { PersonService } from './../../services/person.service';
import { Component, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{

   constructor(public service: PersonService){

   }
  ngOnInit(): void {
    this.service.getAll().subscribe(
      (resp) =>{
        console.log(resp);
      }
    )
  }
}
