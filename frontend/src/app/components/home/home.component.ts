
import { ViewContainerRef } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { ModalService } from 'src/app/services/modal.service';
import { DynamicModalComponent } from '../dynamic-modal/dynamic-modal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']

  
})


export class HomeComponent {
  constructor(private modalService: ModalService) {}

@ViewChild('modal', { read: ViewContainerRef, static: true })
  entry!: ViewContainerRef;
  sub!: Subscription;

openModal() {
// MyComponent é o componente que será renderizado dentro do seu body
    this.sub = this.modalService
      .openModal(this.entry, 'Título do modal', DynamicModalComponent)
      .subscribe((v) => {
        // dispara quando é aberto o modal
      });
  }

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
